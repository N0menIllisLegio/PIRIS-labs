using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs.Common;

namespace PIRIS_labs.Services
{
  public class AccountsService
  {
    private const string _passiveIndividualAccountNumber = "3014";

    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AccountsService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<List<AccountDto>> GetBankAccountsAsync()
    {
      var cashboxAccount = await _unitOfWork.Accounts.GetBankCashboxAccount();
      var fundAccount = await _unitOfWork.Accounts.GetBankDevelopmentFundAccount();

      return new List<AccountDto> { _mapper.Map<AccountDto>(cashboxAccount), _mapper.Map<AccountDto>(fundAccount) };
    }

    public async Task CalculateAccountsBalances()
    {
      var accountsWithTypes = await _unitOfWork.Accounts.GetAccountsWithTypes();

      foreach (var accountWithType in accountsWithTypes)
      {
        switch (accountWithType.AccountType)
        {
          case Enums.AccountType.Passive:
            accountWithType.Account.Balance += accountWithType.Account.CreditValue - accountWithType.Account.DebitValue;
            break;
          case Enums.AccountType.Active:
            accountWithType.Account.Balance += accountWithType.Account.DebitValue - accountWithType.Account.CreditValue;
            break;
          default:
            throw new ArgumentException(nameof(accountWithType.AccountType));
        }

        accountWithType.Account.CreditValue = accountWithType.Account.DebitValue = 0;
      }

      await _unitOfWork.SaveAsync();
    }

    public async Task<(Account main, Account percent)> OpenDepositAccountsAsync(Guid clientID)
    {
      var client = await _unitOfWork.Clients.FindAsync(clientID);
      int accountNumber = _unitOfWork.Accounts.GetClientsLastAccountNumber(clientID);
      var accountPlan = await _unitOfWork.AccountPlans.FindAsync(_passiveIndividualAccountNumber);

      var mainAccount = new Account
      {
        OwnerID = clientID,
        AccountPlan = accountPlan,
        Number = GenerateAccountNumber(_passiveIndividualAccountNumber, client.Number, ++accountNumber)
      };

      var percentAccount = new Account
      {
        OwnerID = clientID,
        AccountPlan = accountPlan,
        Number = GenerateAccountNumber(_passiveIndividualAccountNumber, client.Number, ++accountNumber)
      };

      _unitOfWork.Accounts.Add(mainAccount);
      _unitOfWork.Accounts.Add(percentAccount);

      await _unitOfWork.SaveAsync();

      return (mainAccount, percentAccount);
    }

    private string GenerateAccountNumber(string accountPlanNumber, int clientNumber, int accountNumber)
    {
      return $"{accountPlanNumber}{clientNumber:00000}{accountNumber:000}7";
    }
  }
}