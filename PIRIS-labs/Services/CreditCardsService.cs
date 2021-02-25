using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIRIS_labs.Data;
using PIRIS_labs.DTOs;
using PIRIS_labs.DTOs.ATM;

namespace PIRIS_labs.Services
{
  public class CreditCardsService
  {
    private static readonly Random _randomizer = new Random();

    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly TransactionsService _transactionsService;

    public CreditCardsService(UnitOfWork unitOfWork, IMapper mapper, TransactionsService transactionsService)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _transactionsService = transactionsService;
    }

    public async Task<List<CreditCardDto>> GetCreditCardsAsync()
    {
      var creditCards = await _unitOfWork.CreditCards.GetAllAsync(card => card.Include(p => p.Owner));

      return creditCards.Select(_mapper.Map<CreditCardDto>).ToList();
    }

    public async Task<CreditCardDto> GetCreditCardAsync(Guid creditID)
    {
      var credit = await _unitOfWork.Credits.GetFirstWhereAsync(credit => credit.ID == creditID);
      var creditCard = await _unitOfWork.CreditCards.GetFirstWhereAsync(card => card.CreditAccountNumber == credit.MainAccountNumber);

      return _mapper.Map<CreditCardDto>(creditCard);
    }

    public async Task<BalanceInquiryDto> InquiryBalace(CreditCardDto creditCardDto)
    {
      var creditCard = await _unitOfWork.CreditCards.GetFirstWhereAsync(card => card.Number == creditCardDto.Number);
      var creditAccount = creditCard.CreditAccount;

      return new BalanceInquiryDto
      {
        Balance = creditAccount.Balance + creditAccount.DebitValue - creditAccount.CreditValue,
        Number = $"{creditCard.Number.Substring(0, 4)}*********{creditCard.Number.Substring(12)}",
        ClientFullName = $"{creditCard.Owner.Surname.ToUpper()} {creditCard.Owner.Name.ToUpper()}"
      };
    }

    public async Task<ResultDto> WithdrawCash(CreditCardDto creditCardDto, decimal amount)
    {
      var creditCard = await _unitOfWork.CreditCards.GetFirstWhereAsync(card => card.Number == creditCardDto.Number);

      if (creditCard.CreditAccount.Balance < amount)
      {
        return new ResultDto
        {
          Success = false,
          Message = "Insufficient funds."
        };
      }

      var cashboxAccount = await _unitOfWork.Accounts.GetBankCashboxAccount();

      var transaction = await _transactionsService.CreateTransaction(creditCard.CreditAccount, cashboxAccount, amount);
      cashboxAccount.CreditValue += amount;

      await _unitOfWork.SaveAsync();

      return new ResultDto { Success = true, Message = transaction.ID.ToString() };
    }

    public async Task<CashWithdrawlDto> GetCashWithdrawlDtoAsync(CreditCardDto creditCardDto, Guid transactionID)
    {
      var creditCard = await _unitOfWork.CreditCards.GetFirstWhereAsync(card => card.Number == creditCardDto.Number);

      var transaction = await _unitOfWork.Transactions.FindAsync(transactionID);

      return new CashWithdrawlDto
      {
        Number = $"{creditCard.Number.Substring(0, 4)}*********{creditCard.Number.Substring(12)}",
        ClientFullName = $"{creditCard.Owner.Surname.ToUpper()} {creditCard.Owner.Name.ToUpper()}",
        TransactionTime = transaction.TransactionTime,
        CreditAccountNumber = creditCard.CreditAccountNumber,
        Amount = transaction.Amount
      };
    }

    public async Task<ResultDto> PutMoneyOnMobilePhone(CreditCardDto creditCardDto, AtmMobilePhoneDto mobilePhoneDto)
    {
      var creditCard = await _unitOfWork.CreditCards.GetFirstWhereAsync(card => card.Number == creditCardDto.Number);

      if (creditCard.CreditAccount.Balance < mobilePhoneDto.Amount)
      {
        return new ResultDto
        {
          Success = false,
          Message = "Insufficient funds."
        };
      }

      var cashboxAccount = await _unitOfWork.Accounts.GetBankCashboxAccount();

      var transaction = await _transactionsService.CreateTransaction(creditCard.CreditAccount, cashboxAccount, mobilePhoneDto.Amount);
      cashboxAccount.CreditValue += mobilePhoneDto.Amount;

      await _unitOfWork.SaveAsync();

      return new ResultDto { Success = true, Message = transaction.ID.ToString() };
    }

    public async Task<bool> Authenticate(CreditCardDto creditCardDto)
    {
      var creditCard = await _unitOfWork.CreditCards.GetFirstWhereAsync(card => card.Number == creditCardDto.Number);
      return creditCard is not null && creditCard.PIN == creditCardDto.PIN;
    }

    public async Task<string> GenerateCreditCardNumber()
    {
      string creditCardNumber;

      do
      {
        creditCardNumber = $"42551004{_randomizer.Next(99999999):00000000}";
      }
      while (await _unitOfWork.CreditCards.GetFirstWhereAsync(creditCard => creditCard.Number == creditCardNumber) is not null);

      return creditCardNumber;
    }
  }
}