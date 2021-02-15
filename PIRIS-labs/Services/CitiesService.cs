using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.DTOs.City;

namespace PIRIS_labs.Services
{
  public class CitiesService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CitiesService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<IEnumerable<CityDto>> GetCitiesAsync()
    {
      var cities = await _unitOfWork.Cities.GetAllAsync();
      return cities.Select(_mapper.Map<CityDto>);
    }

    public async Task<CityDto> GetCityAsync(string name)
    {
      var city = await _unitOfWork.Cities.FindAsync(name);
      return _mapper.Map<CityDto>(city);
    }
  }
}
