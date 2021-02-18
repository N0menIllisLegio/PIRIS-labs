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

    public DepositsService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<List<DepositDto>> GetDepositsAsync()
    {
      var deposits = await _unitOfWork.Deposits.GetAllAsync(deposit => deposit.Include(p => p.PercentAccount).Include(p => p.Client).Include(p => p.DepositPlan));

      return deposits.Select(_mapper.Map<DepositDto>).ToList();
    }

    public async Task<ResultDto> CreateDepositAsync(CreateDepositDto createDepositDto)
    {
      var client = await _unitOfWork.Clients.FindAsync(createDepositDto.ClientID);
      var depositPlan = await _unitOfWork.DepositPlans.FindAsync(createDepositDto.DepositPlanID);

      var deposit = new Deposit
      {
        Client = client,
        DepositPlan = depositPlan,
        Amount = createDepositDto.Amount,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now.AddDays(depositPlan.DayPeriod),
      };

      _unitOfWork.Deposits.Add(deposit);

      await _unitOfWork.SaveAsync();

      return new ResultDto { Success = true };
    }
  }
}
