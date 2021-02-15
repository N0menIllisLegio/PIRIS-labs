using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.DTOs.Nationality;

namespace PIRIS_labs.Services
{
  public class NationalitiesService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public NationalitiesService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<IEnumerable<NationalityDto>> GetNationalitiesAsync()
    {
      var nationalities = await _unitOfWork.Nationalities.GetAllAsync();
      return nationalities.Select(_mapper.Map<NationalityDto>);
    }

    public async Task<NationalityDto> GetNationalityAsync(string name)
    {
      var nationality = await _unitOfWork.Nationalities.FindAsync(name);
      return _mapper.Map<NationalityDto>(nationality);
    }
  }
}
