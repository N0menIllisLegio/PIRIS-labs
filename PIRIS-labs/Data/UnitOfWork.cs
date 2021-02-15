﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using PIRIS_labs.Data.Repositories;

namespace PIRIS_labs.Data
{
  public class UnitOfWork : IDisposable
  {
    private readonly ApplicationDbContext _applicationDbContext;
    private ClientsRepository _clientsRepository;
    private CitiesRepository _citiesRepository;
    private DisabilitiesRepository _disabilitiesRepository;
    private MaritalStatusesRepository _maritalStatusesRepository;
    private NationalitiesRepository _nationalitiesRepository;
    private bool _disposed = false;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
      _applicationDbContext = applicationDbContext;
    }

    public ClientsRepository Clients => _clientsRepository = _clientsRepository ?? new ClientsRepository(_applicationDbContext);
    public CitiesRepository Cities => _citiesRepository = _citiesRepository ?? new CitiesRepository(_applicationDbContext);
    public DisabilitiesRepository Disabilities => _disabilitiesRepository = _disabilitiesRepository ?? new DisabilitiesRepository(_applicationDbContext);
    public MaritalStatusesRepository MaritalStatuses => _maritalStatusesRepository = _maritalStatusesRepository ?? new MaritalStatusesRepository(_applicationDbContext);
    public NationalitiesRepository Nationalities => _nationalitiesRepository = _nationalitiesRepository ?? new NationalitiesRepository(_applicationDbContext);

    public async Task<bool> SaveAsync()
    {
      try
      {
        await _applicationDbContext.SaveChangesAsync();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public IDbContextTransaction BeginTransaction()
    {
      return _applicationDbContext.Database.BeginTransaction();
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!_disposed)
      {
        if (disposing)
        {
          // TODO: dispose managed state (managed objects).
          _applicationDbContext.Dispose();
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposed = true;
      }
    }

    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~UnitOfWork()
    // {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      // TODO: uncomment the following line if the finalizer is overridden above.
      // GC.SuppressFinalize(this);
    }
  }
}
