using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.DTOs.MaritalStatus;

namespace PIRIS_labs.Services
{
  public class MaritalStatusesService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MaritalStatusesService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<IEnumerable<MaritalStatusDto>> GetMaritalStatusesAsync()
    {
      var maritalStatuses = await _unitOfWork.MaritalStatuses.GetAllAsync();
      return maritalStatuses.Select(_mapper.Map<MaritalStatusDto>);
    }

    public async Task<MaritalStatusDto> GetMaritalStatusAsync(string name)
    {
      var maritalStatus = await _unitOfWork.MaritalStatuses.FindAsync(name);
      return _mapper.Map<MaritalStatusDto>(maritalStatus);
    }
  }
}
