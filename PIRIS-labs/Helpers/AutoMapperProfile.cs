using AutoMapper;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs.City;
using PIRIS_labs.DTOs.Client;
using PIRIS_labs.DTOs.Disability;
using PIRIS_labs.DTOs.MaritalStatus;
using PIRIS_labs.DTOs.Nationality;

namespace PIRIS_labs.Helpers
{
  public class AutoMapperProfile: Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Client, ClientDto>()
        .ForMember(dest => dest.ActualResidenceCity, opt => opt.MapFrom(src => src.ActualResidenceCity.Name))
        .ForMember(dest => dest.RegistrationCity, opt => opt.MapFrom(src => src.RegistrationCity.Name))
        .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus.Name))
        .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality.Name))
        .ForMember(dest => dest.Disability, opt => opt.MapFrom(src => src.Disability.Name));

      CreateMap<City, CityDto>();
      CreateMap<Disability, DisabilityDto>();
      CreateMap<MaritalStatus, MaritalStatusDto>();
      CreateMap<Nationality, NationalityDto>();
    }
  }
}
