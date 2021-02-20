using AutoMapper;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs.Client;
using PIRIS_labs.DTOs.Deposit;

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

      // TODO change
      CreateMap<Deposit, DepositDto>()
        .ForMember(dest => dest.DepositPlan, opt => opt.MapFrom(src => src.DepositPlan.Name))
        .ForMember(dest => dest.Client, opt => opt.MapFrom(src => $"{src.Client.Surname} {src.Client.Name} {src.Client.Patronymic}"))
        .ForMember(dest => dest.AccumulatedAmount, opt => opt.MapFrom(src => src.PercentAccount.Balance));

      CreateMap<CreateDepositDto, Deposit>();
    }
  }
}
