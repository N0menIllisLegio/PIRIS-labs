using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
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
  }
}
