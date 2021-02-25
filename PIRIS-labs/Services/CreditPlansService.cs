using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs;
using PIRIS_labs.DTOs.Credit;

namespace PIRIS_labs.Services
{
  public class CreditPlansService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreditPlansService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<List<CreditPlanDto>> GetCreditPlansAsync()
    {
      var creditPlans = await _unitOfWork.CreditPlans.GetCreditPlansOrderedAsync();

      return creditPlans.Select(_mapper.Map<CreditPlanDto>).ToList();
    }

    public async Task<ResultDto> CreateCreditPlanAsync(CreditPlanDto creditPlanDto)
    {
      var creditPlan = _mapper.Map<CreditPlan>(creditPlanDto);

      _unitOfWork.CreditPlans.Add(creditPlan);

      await _unitOfWork.SaveAsync();

      return new ResultDto { Success = true };
    }
  }
}
