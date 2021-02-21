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

namespace PIRIS_labs.Services
{
  public class CreditsService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly AccountsService _accountsService;
    private readonly TransactionsService _transactionsService;

    public CreditsService(UnitOfWork unitOfWork, IMapper mapper,
      AccountsService accountsService, TransactionsService transactionsService)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _accountsService = accountsService;
      _transactionsService = transactionsService;
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
          credit.StartDate = DateTime.Today;
          credit.EndDate = DateTime.Today.AddMonths(creditPlan.MonthPeriod);

          var (mainAccount, percentAccount) = await _accountsService.OpenCreditAccountsAsync(credit.ClientID);

          credit.MainAccount = mainAccount;
          credit.PercentAccount = percentAccount;

          await _unitOfWork.SaveAsync();

          decimal amount = createCreditDto.Amount;
          var cashboxAccount = await _unitOfWork.Accounts.GetBankCashboxAccount();
          var developmentFundAccount = await _unitOfWork.Accounts.GetBankDevelopmentFundAccount();

          await _transactionsService.CreateTransaction(developmentFundAccount, mainAccount, amount);
          await _transactionsService.CreateTransaction(mainAccount, cashboxAccount, amount);
          cashboxAccount.CreditValue += amount;

          _unitOfWork.Credits.Add(credit);
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

    public List<CreditPercentsDto> CalculateCreditPaymentPlan(decimal creditAmount, decimal yearPercent, int months, bool anuity)
    {
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
          Date = DateTime.Today.AddMonths(monthsPassed),
          MainDebth = Math.Round(mainDebth, 2),
          PercentDebth = Math.Round(percentDebth, 2),
          PaymentSum = Math.Round(mainDebth + percentDebth, 2)
        });
      }

      return result;
    }
  }
}
