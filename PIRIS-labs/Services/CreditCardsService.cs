using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIRIS_labs.Data;
using PIRIS_labs.DTOs.ATM;

namespace PIRIS_labs.Services
{
  public class CreditCardsService
  {
    private static readonly Random _randomizer = new Random();

    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreditCardsService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<List<CreditCardDto>> GetCreditCardsAsync()
    {
      var creditCards = await _unitOfWork.CreditCards.GetAllAsync(card => card.Include(p => p.Owner));

      return creditCards.Select(_mapper.Map<CreditCardDto>).ToList();
    }

    public async Task<string> GenerateCreditCardNumber()
    {
      string creditCardNumber;

      do
      {
        creditCardNumber = $"42551004{_randomizer.Next(99999999):00000000}";
      }
      while (await _unitOfWork.CreditCards.GetFirstWhereAsync(creditCard => creditCard.Number == creditCardNumber) is not null);

      return creditCardNumber;
    }
  }
}
