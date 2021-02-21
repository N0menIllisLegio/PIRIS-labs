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

    public BankOperationsService(UnitOfWork unitOfWork, IMapper mapper,
      DepositsService depositsService, AccountsService accountsService, CreditsService creditsService)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _depositsService = depositsService;
      _accountsService = accountsService;
      _creditsService = creditsService;
    }

    public async Task<ResultDto> CloseDayAsync()
    {
      using var transaction = _unitOfWork.BeginTransaction();

      try
      {
        await _depositsService.CalculateDepositsPercents();
        await _creditsService.CalculateCreditsPercents();
        await _accountsService.CalculateAccountsBalances();

        await transaction.CommitAsync();
      }
      catch (System.Exception ex)
      {
        await transaction.RollbackAsync();
        return new ResultDto { Success = false, Message = ex.Message };
      }

      return new ResultDto { Success = true };
    }
  }
}
