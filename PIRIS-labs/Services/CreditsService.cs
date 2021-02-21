using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.DTOs.Credit;

namespace PIRIS_labs.Services
{
  public class CreditsService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreditsService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<List<CreditDto>> GetCreditsAsync()
    {
      var deposits = await _unitOfWork.Credits.GetAllAsync();
        //GetOrderedDepositsAsync(deposit => deposit
        //.Include(p => p.PercentAccount)
        //.Include(p => p.Client)
        //.Include(p => p.DepositPlan));

      return deposits.Select(_mapper.Map<CreditDto>).ToList();
    }
  }
}
