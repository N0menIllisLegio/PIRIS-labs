using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Services
{
  public class AccountsService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AccountsService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    //public async Task<Account> OpenAccountAsync(decimal amount)
    //{
    //  var account = new Account
    //  {
    //  };
    //}
  }
}
