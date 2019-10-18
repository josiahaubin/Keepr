using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Keep> Get()
    {
      throw new NotImplementedException();
    }
    public IEnumerable<Keep> GetUserKeeps()
    {
      throw new NotImplementedException();
    }
    public Keep Get(int keepId)
    {
      throw new NotImplementedException();
    }
    public Keep Create(Keep newKeep)
    {
      throw new NotImplementedException();
    }
    public Keep Edit(Keep editKeep)
    {
      throw new NotImplementedException();
    }
    public string Remove(int keepId)
    {
      throw new NotImplementedException();
    }
  }
}