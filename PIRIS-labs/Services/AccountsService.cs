using System;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.Data.Entities;

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

    public async Task<(Account main, Account percent)> OpenDepositAccountsAsync(Guid clientID)
    {
      var client = await _unitOfWork.Clients.FindAsync(clientID);
      int accountNumber = _unitOfWork.Accounts.GetClientsLastAccountNumber(clientID);

      var mainAccount = new Account
      {
        OwnerID = clientID,
        AccountPlanNumber = _passiveIndividualAccountNumber,
        Number = GenerateAccountNumber(_passiveIndividualAccountNumber, client.Number, ++accountNumber)
      };

      var percentAccount = new Account
      {
        OwnerID = clientID,
        AccountPlanNumber = _passiveIndividualAccountNumber,
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