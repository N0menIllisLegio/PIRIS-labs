using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIRIS_labs.Data;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs;
using PIRIS_labs.DTOs.Deposit;

namespace PIRIS_labs.Services
{
  public class DepositsService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly AccountsService _accountsService;
    private readonly TransactionsService _transactionsService;

    public DepositsService(UnitOfWork unitOfWork, IMapper mapper,
      AccountsService accountsService, TransactionsService transactionsService)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _accountsService = accountsService;
      _transactionsService = transactionsService;
    }

    public async Task<List<DepositDto>> GetDepositsAsync()
    {
      var deposits = await _unitOfWork.Deposits.GetAllAsync(deposit => deposit
      .Include(p => p.PercentAccount)
      .Include(p => p.Client)
      .Include(p => p.DepositPlan));

      return deposits.Select(_mapper.Map<DepositDto>).ToList();
    }

    public async Task<ResultDto> CreateDepositAsync(CreateDepositDto createDepositDto)
    {
      if (createDepositDto.Amount <= 0)
      {
        return new ResultDto { Success = false, Message = "Amount should be greater than 0" };
      }

      using (var transaction = _unitOfWork.BeginTransaction())
      {
        try
        {
          var deposit = _mapper.Map<Deposit>(createDepositDto);
          var depositPlan = await _unitOfWork.DepositPlans.FindAsync(createDepositDto.DepositPlanID);
          deposit.StartDate = DateTime.Today;
          deposit.EndDate = DateTime.Today.AddDays(depositPlan.DayPeriod);

          var (mainAccount, percentAccount) = await _accountsService.OpenDepositAccountsAsync(deposit.ClientID);

          deposit.MainAccount = mainAccount;
          deposit.PercentAccount = percentAccount;

          await _unitOfWork.SaveAsync();

          decimal amount = createDepositDto.Amount;
          var cashboxAccount = await _unitOfWork.Accounts.GetBankCashboxAccount();
          var developmentFundAccount = await _unitOfWork.Accounts.GetBankDevelopmentFundAccount();

          cashboxAccount.DebitValue += amount;
          await _transactionsService.CreateTransaction(cashboxAccount, mainAccount, amount);
          await _transactionsService.CreateTransaction(mainAccount, developmentFundAccount, amount);

          _unitOfWork.Deposits.Add(deposit);
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
  }
}