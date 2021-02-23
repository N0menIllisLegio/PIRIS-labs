using System;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.Enums;

namespace PIRIS_labs.Services
{
  public class TransactionsService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly DateService _dateService;

    public TransactionsService(UnitOfWork unitOfWork, IMapper mapper, DateService dateService)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _dateService = dateService;
    }

    public async Task<Transaction> CreateTransaction(Account fromAccount, Account toAccount, decimal amount)
    {
      if (amount <= 0 || fromAccount is null || toAccount is null)
      {
        return null;
      }

      var transaction = new Transaction
      {
        Amount = amount,
        TransactionTime = _dateService.Today,
        TransferFromAccount = fromAccount,
        TransferToAccount = toAccount
      };

      Expenditure(fromAccount, amount);
      Income(toAccount, amount);

      _unitOfWork.Transactions.Add(transaction);
      await _unitOfWork.SaveAsync();

      return transaction;
    }

    private Account Income(Account account, decimal amount)
    {
      switch (account.AccountPlan.Type)
      {
        case AccountType.Active:
          account.DebitValue += amount;
          break;

        case AccountType.Passive:
          account.CreditValue += amount;
          break;

        default:
          throw new ArgumentException(nameof(account.AccountPlan.Type));
      }

      return account;
    }

    private Account Expenditure(Account account, decimal amount)
    {
      switch (account.AccountPlan.Type)
      {
        case AccountType.Active:
          account.CreditValue += amount;
          break;

        case AccountType.Passive:
          account.DebitValue += amount;
          break;

        default:
          throw new ArgumentException(nameof(account.AccountPlan.Type));
      }

      return account;
    }
  }
}
