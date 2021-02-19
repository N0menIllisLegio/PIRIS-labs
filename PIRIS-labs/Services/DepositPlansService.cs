using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs;
using PIRIS_labs.DTOs.Deposit;

namespace PIRIS_labs.Services
{
  public class DepositPlansService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepositPlansService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<List<DepositPlanDto>> GetDepositPlansAsync()
    {
      var plans = await _unitOfWork.DepositPlans.GetDepositPlansOrderedAsync();

      return plans.Select(_mapper.Map<DepositPlanDto>).ToList();
    }

    public async Task<ResultDto> CreateDepositPlanAsync(DepositPlanDto depositPlanDto)
    {
      var depositPlan = _mapper.Map<DepositPlan>(depositPlanDto);

      _unitOfWork.DepositPlans.Add(depositPlan);

      await _unitOfWork.SaveAsync();

      return new ResultDto { Success = true };
    }
  }
}