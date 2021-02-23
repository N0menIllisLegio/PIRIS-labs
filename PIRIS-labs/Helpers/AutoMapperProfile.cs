using AutoMapper;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs.ATM;
using PIRIS_labs.DTOs.Client;
using PIRIS_labs.DTOs.Common;
using PIRIS_labs.DTOs.Credit;
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

      CreateMap<Account, AccountDto>()
        .ForMember(dest => dest.AccountPlanName, opt => opt.MapFrom(src => src.AccountPlan.Name));

      CreateMap<DepositPlan, DepositPlanDto>().ReverseMap();
      CreateMap<CreateDepositDto, Deposit>();
      CreateMap<Deposit, DepositDto>()
        .ForMember(dest => dest.DepositPlan, opt => opt.MapFrom(src => src.DepositPlan.Name))
        .ForMember(dest => dest.Revocable, opt => opt.MapFrom(src => src.DepositPlan.Revocable))
        .ForMember(dest => dest.Client, opt => opt.MapFrom(src => $"{src.Client.Surname} {src.Client.Name} {src.Client.Patronymic}"))
        .ForMember(dest => dest.AccumulatedAmount, opt => opt.MapFrom(src => src.PercentAccount.Balance));

      CreateMap<CreditPlan, CreditPlanDto>().ReverseMap();
      CreateMap<CreateCreditDto, Credit>();
      CreateMap<Credit, CreditDto>()
        .ForMember(dest => dest.CreditPlan, opt => opt.MapFrom(src => src.CreditPlan.Name))
        .ForMember(dest => dest.Anuity, opt => opt.MapFrom(src => src.CreditPlan.Anuity))
        .ForMember(dest => dest.Client, opt => opt.MapFrom(src => $"{src.Client.Surname} {src.Client.Name} {src.Client.Patronymic}"))
        .ForMember(dest => dest.MonthlyPayment, opt => opt.MapFrom(src => src.PercentAccount.Balance));

      CreateMap<CreditCard, CreditCardDto>()
        .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToString("MM/yy")))
        .ForMember(dest => dest.OwnerFullName, opt => opt.MapFrom(src => $"{src.Owner.Name.ToUpper()} {src.Owner.Surname.ToUpper()}"));
    }
  }
}
