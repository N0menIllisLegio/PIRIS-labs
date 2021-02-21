using AutoMapper;
using PIRIS_labs.Data;

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
  }
}
