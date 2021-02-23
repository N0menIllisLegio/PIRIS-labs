using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIRIS_labs.Data;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs;
using PIRIS_labs.DTOs.Credit;
using PIRIS_labs.Helpers;

namespace PIRIS_labs.Services
{
  public class CreditsService
  {
    private static readonly Random _randomizer = new Random();

    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly AccountsService _accountsService;
    private readonly TransactionsService _transactionsService;
    private readonly CreditCardsService _creditCardsService;
    private readonly DateService _dateService;

    public CreditsService(UnitOfWork unitOfWork, IMapper mapper,
      AccountsService accountsService, TransactionsService transactionsService,
      CreditCardsService creditCardsService, DateService dateService)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _accountsService = accountsService;
      _transactionsService = transactionsService;
      _creditCardsService = creditCardsService;
      _dateService = dateService;
    }

    public static int GetMonthDifference(DateTime startDate, DateTime endDate)
    {
      int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
      return Math.Abs(monthsApart);
    }

    public async Task<List<CreditDto>> GetCreditsAsync()
    {
      var deposits = await _unitOfWork.Credits.GetOrderedCreditsAsync(credit => credit
        .Include(p => p.PercentAccount)
        .Include(p => p.Client)
        .Include(p => p.CreditPlan));

      return deposits.Select(_mapper.Map<CreditDto>).ToList();
    }

    public async Task<ResultDto> CreateCreditAsync(CreateCreditDto createCreditDto)
    {
      if (createCreditDto.Amount <= 0)
      {
        return new ResultDto { Success = false, Message = "Amount should be greater than 0" };
      }

      using (var transaction = _unitOfWork.BeginTransaction())
      {
        try
        {
          var credit = _mapper.Map<Credit>(createCreditDto);
          var creditPlan = await _unitOfWork.CreditPlans.FindAsync(createCreditDto.CreditPlanID);
          credit.StartDate = _dateService.Today;
          credit.EndDate = _dateService.Today.AddMonths(creditPlan.MonthPeriod);

          var (mainAccount, percentAccount) = await _accountsService.OpenCreditAccountsAsync(credit.ClientID);

          credit.MainAccount = mainAccount;
          credit.PercentAccount = percentAccount;

          await _unitOfWork.SaveAsync();

          decimal amount = createCreditDto.Amount;
          var cashboxAccount = await _unitOfWork.Accounts.GetBankCashboxAccount();
          var developmentFundAccount = await _unitOfWork.Accounts.GetBankDevelopmentFundAccount();

          await _transactionsService.CreateTransaction(developmentFundAccount, mainAccount, amount);
          _unitOfWork.Credits.Add(credit);

          var creditCard = new CreditCard
          {
            CreditAccount = mainAccount,
            EndDate = credit.EndDate,
            OwnerID = credit.ClientID,

            PIN = $"{_randomizer.Next(0, 9999):0000}",
            Number = await _creditCardsService.GenerateCreditCardNumber()
          };

          _unitOfWork.CreditCards.Add(creditCard);
          await _unitOfWork.SaveAsync();

          await transaction.CommitAsync();

          return new ResultDto { Success = true };
        }
        catch (Exception ex)
        {
          await transaction.RollbackAsync();
          return new ResultDto { Success = false, Message = ex.Message };
        }
      }
    }

    public async Task<ResultDto> CloseCreditAsync(Guid creditID)
    {
      using (var transaction = _unitOfWork.BeginTransaction())
      {
        try
        {
          var credit = await _unitOfWork.Credits.FindAsync(creditID);

          if (credit is null)
          {
            return new ResultDto { Success = false, Message = "Deposit Not Found" };
          }

          var clientMainAccount = credit.MainAccount;
          var clientPercentAccount = credit.PercentAccount;
          var cashboxAccount = await _unitOfWork.Accounts.GetBankCashboxAccount();
          var developmentFundAccount = await _unitOfWork.Accounts.GetBankDevelopmentFundAccount();

          if (clientPercentAccount.Balance < 0)
          {
            decimal percentDebth = Math.Abs(clientPercentAccount.Balance);
            cashboxAccount.DebitValue += percentDebth;
            await _transactionsService.CreateTransaction(cashboxAccount, clientPercentAccount, percentDebth);
          }

          decimal creditDebthAmount = clientMainAccount.Balance - CalculateCreditDebthAmount(credit);
          if (creditDebthAmount > 0)
          {
            cashboxAccount.DebitValue += creditDebthAmount;
            await _transactionsService.CreateTransaction(cashboxAccount, clientMainAccount, creditDebthAmount);
            await _transactionsService.CreateTransaction(clientMainAccount, developmentFundAccount, creditDebthAmount);
          }

          credit.Closed = true;

          await _unitOfWork.SaveAsync();

          await transaction.CommitAsync();

          return new ResultDto { Success = true };
        }
        catch (Exception ex)
        {
          await transaction.RollbackAsync();
          return new ResultDto { Success = false, Message = ex.Message };
        }
      }
    }

    private decimal CalculateCreditDebthAmount(Credit credit)
    {
      var creditPlan = credit.CreditPlan;
      var creditPaymentPlan = CalculateCreditPaymentPlan(credit.Amount, creditPlan.Percent, creditPlan.MonthPeriod, creditPlan.Anuity, credit.StartDate);

      return creditPaymentPlan.Aggregate(0m, (debth, nextPayment) => nextPayment.Date >= _dateService.Today ? debth += nextPayment.PaymentSum : debth);
    }

    public List<CreditPercentsDto> CalculateCreditPaymentPlan(decimal creditAmount, decimal yearPercent, int months, bool anuity,
      DateTime startDate)
    {
      yearPercent /= 100;
      var result = new List<CreditPercentsDto>();
      decimal mainDebth;

      if (anuity)
      {
        double monthPercent = (double)yearPercent / 12;
        double coef = monthPercent * Math.Pow(1 + monthPercent, months) / (Math.Pow(1 + monthPercent, months) - 1);
        mainDebth = creditAmount * (decimal)coef;
      }
      else
      {
        mainDebth = creditAmount / months;
      }

      for (int monthsPassed = 0; monthsPassed < months; monthsPassed++)
      {
        decimal percentDebth = anuity
          ? 0
          : (creditAmount - (mainDebth * monthsPassed)) * yearPercent / 12;

        result.Add(new CreditPercentsDto
        {
          RowNumber = monthsPassed + 1,
          Date = startDate.AddMonths(monthsPassed),
          MainDebth = Math.Round(mainDebth, 2),
          PercentDebth = Math.Round(percentDebth, 2),
          PaymentSum = Math.Round(mainDebth + percentDebth, 2)
        });
      }

      return result;
    }

    public async Task CalculateCreditsPercents()
    {
      var creditPercentAccounts = await _unitOfWork.Credits.GetOpenCreditPercentAccounts();
      var developmentFundAccount = await _unitOfWork.Accounts.GetBankDevelopmentFundAccount();

      foreach (var creditPercentAccount in creditPercentAccounts)
      {
        decimal paymentAmount;

        creditPercentAccount.CreditPercent /= 100;

        if (creditPercentAccount.Anuity)
        {
          double monthPercent = (double)creditPercentAccount.CreditPercent / 12;
          double mainDebth = monthPercent * Math.Pow(1 + monthPercent, creditPercentAccount.Months) / (Math.Pow(1 + monthPercent, creditPercentAccount.Months) - 1);
          paymentAmount = creditPercentAccount.CreditAmount * (decimal)mainDebth;
        }
        else
        {
          int monthsPassed = _dateService.Today.GetMonthDifference(creditPercentAccount.StartDate);

          decimal mainDebth = creditPercentAccount.CreditAmount / creditPercentAccount.Months;
          decimal percentDebth = (creditPercentAccount.CreditAmount - (mainDebth * monthsPassed)) * creditPercentAccount.CreditPercent / 12;
          paymentAmount = mainDebth + percentDebth;

          // Here we calculate payment amount in 1 day, not a month
          paymentAmount /= DateTime.DaysInMonth(_dateService.Today.Year, _dateService.Today.Month);
        }

        await _transactionsService.CreateTransaction(creditPercentAccount.PercentAccount, developmentFundAccount, paymentAmount);
      }
    }
  }
}
