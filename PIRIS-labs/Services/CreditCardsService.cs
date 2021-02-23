using AutoMapper;
using PIRIS_labs.Data;

namespace PIRIS_labs.Services
{
  public class CreditCardsService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreditCardsService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public string GenerateCreditCardNumber()
    {

    }
  }
}
