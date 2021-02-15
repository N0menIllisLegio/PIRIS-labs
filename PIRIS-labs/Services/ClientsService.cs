using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIRIS_labs.Data;
using PIRIS_labs.DTOs.Client;

namespace PIRIS_labs.Services
{
  public class ClientsService
  {
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClientsService(UnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ClientDto>> GetClientsAsync()
    {
      var clients = await _unitOfWork.Clients.GetAllAsync();
      return clients.Select(_mapper.Map<ClientDto>);
    }

    public async Task<ClientDto> GetClientAsync(Guid id)
    {
      var client = await _unitOfWork.Clients.FindAsync(id);
      return _mapper.Map<ClientDto>(client);
    }
  }
}
