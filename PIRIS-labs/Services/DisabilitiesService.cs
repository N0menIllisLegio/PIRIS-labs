using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.DTOs.Disability;

namespace PIRIS_labs.Services
{
  public class DisabilitiesService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DisabilitiesService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<IEnumerable<DisabilityDto>> GetDisabilitiesAsync()
    {
      var disabilities = await _unitOfWork.Disabilities.GetAllAsync();
      return disabilities.Select(_mapper.Map<DisabilityDto>);
    }

    public async Task<DisabilityDto> GetDisabilityAsync(string name)
    {
      var disability = await _unitOfWork.Disabilities.FindAsync(name);
      return _mapper.Map<DisabilityDto>(disability);
    }
  }
}
