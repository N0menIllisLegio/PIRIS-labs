using AutoMapper;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs.City;
using PIRIS_labs.DTOs.Client;
using PIRIS_labs.DTOs.Deposit;
using PIRIS_labs.DTOs.Disability;
using PIRIS_labs.DTOs.MaritalStatus;
using PIRIS_labs.DTOs.Nationality;

namespace PIRIS_labs.Helpers
{
  public class AutoMapperProfile: Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Client, ClientDto>().ReverseMap();
      CreateMap<City, CityDto>();
      CreateMap<Disability, DisabilityDto>();
      CreateMap<MaritalStatus, MaritalStatusDto>();
      CreateMap<Nationality, NationalityDto>();
      CreateMap<DepositPlan, DepositPlanDto>().ReverseMap();
    }
  }
}
