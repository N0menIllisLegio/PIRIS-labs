using AutoMapper;
using PIRIS_labs.Data;

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
  }
}
