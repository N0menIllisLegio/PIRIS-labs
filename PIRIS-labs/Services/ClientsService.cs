using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs;
using PIRIS_labs.DTOs.Client;

namespace PIRIS_labs.Services
{
  public class ClientsService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClientsService(UnitOfWork unitOfWork, IMapper mapper,
      CreditsService creditsService,
      DepositsService depositsService,
      AccountsService accountsService)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ClientDto>> GetClientsAsync()
    {
      var clients = await _unitOfWork.Clients.GetClientSurnameOrderedAsync();
      return clients.Select(_mapper.Map<ClientDto>);
    }

    public async Task<ClientDto> GetClientAsync(Guid id)
    {
      var client = await _unitOfWork.Clients.FindAsync(id);
      return _mapper.Map<ClientDto>(client);
    }

    public async Task<ResultDto> CreateClient(ClientDto clientDto)
    {
      bool unique = await CheckUniqueness(clientDto);
      if (!unique)
      {
        return new ResultDto { Success = false, Message = "Client with this IdentificationNumber already exists!" };
      }

      var newClient = _mapper.Map<Client>(clientDto);
      _unitOfWork.Clients.Add(newClient);
      await _unitOfWork.SaveAsync();

      return new ResultDto { Success = true };
    }

    public async Task<ResultDto> UpdateClient(Guid clientID, ClientDto clientDto)
    {
      bool unique = await CheckUniqueness(clientDto, clientID);
      if (!unique)
      {
        return new ResultDto { Success = false, Message = "Client with this IdentificationNumber already exists!" };
      }

      var dbclient = await _unitOfWork.Clients.FindAsync(clientID);
      _mapper.Map(clientDto, dbclient);
      await _unitOfWork.SaveAsync();

      return new ResultDto { Success = true };
    }

    public async Task<ResultDto> DeleteClient(Guid clientID)
    {
      var client = await _unitOfWork.Clients.FindAsync(clientID);

      if (client is null)
      {
        return new ResultDto
        {
          Success = false,
          Message = "User not found."
        };
      }

      var clientCredits = await _unitOfWork.Credits.GetAllByWhereAsync(credit => credit.ClientID == clientID);
      var clientDeposits = await _unitOfWork.Deposits.GetAllByWhereAsync(deposit => deposit.ClientID == clientID);

      if (clientCredits.Any(credit => !credit.Closed) || clientDeposits.Any(deposit => !deposit.Closed))
      {
        return new ResultDto
        {
          Success = false,
          Message = "Cannot delete user with not closed deposits or credits."
        };
      }

      var clientAccounts = await _unitOfWork.Accounts.GetAllByWhereAsync(account => account.OwnerID == clientID);
      var accountsNumbers = clientAccounts.Select(account => account.Number).ToList();

      var accountsTransactions = await _unitOfWork.Transactions.GetAllByWhereAsync(transaction =>
        accountsNumbers.Contains(transaction.TransferFromAccountNumber) || accountsNumbers.Contains(transaction.TransferToAccountNumber));

      _unitOfWork.Transactions.RemoveRange(accountsTransactions);
      _unitOfWork.Credits.RemoveRange(clientCredits);
      _unitOfWork.Deposits.RemoveRange(clientDeposits);
      _unitOfWork.Accounts.RemoveRange(clientAccounts);
      _unitOfWork.Clients.Remove(client);

      var result = new ResultDto
      {
        Success = await _unitOfWork.SaveAsync(),
        Message = "Remove all client's accounts, deposits etc. to delete him."
      };

      return result;
    }

    private async Task<bool> CheckUniqueness(ClientDto client, Guid? id = null)
    {
      var foundClient = await _unitOfWork.Clients.GetFirstWhereAsync(dbclient =>
        (!id.HasValue || dbclient.ID != id.Value) && (dbclient.IdentificationNumber == client.IdentificationNumber
          || (dbclient.PassportSeries == client.PassportSeries && dbclient.PassportNumber == client.PassportNumber)));

      return foundClient is null;
    }
  }
}
