using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.DTOs;

namespace PIRIS_labs.Services
{
  public class BankOperationsService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DepositsService _depositsService;
        private readonly AccountsService _accountsService;
        private readonly CreditsService _creditsService;
        private readonly DateService _dateService;

        public BankOperationsService(UnitOfWork unitOfWork, IMapper mapper,
          DepositsService depositsService, AccountsService accountsService, CreditsService creditsService,
          DateService dateService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _depositsService = depositsService;
            _accountsService = accountsService;
            _creditsService = creditsService;
            _dateService = dateService;
        }

        public async Task<ResultDto> CloseDaysAsync(int closeDays = 1)
        {
            try
            {
                for (int i = 0; i < closeDays; i++)
                {
                    await _depositsService.CalculateDepositsPercents();
                    await _creditsService.CalculateCreditsPercents();
                    await _accountsService.CalculateAccountsBalances();

                    _dateService.DaysPassed(1);
                }
            }
            catch (System.Exception ex)
            {
                return new ResultDto { Success = false, Message = ex.Message };
            }

            return new ResultDto { Success = true };
        }
    }
}