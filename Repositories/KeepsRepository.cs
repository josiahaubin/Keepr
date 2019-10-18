using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> Get()
    {
      throw new NotImplementedException();
    }

    internal Keep Get(int keepId)
    {
      throw new NotImplementedException();
    }

    internal int Create(Keep newKeep)
    {
      throw new NotImplementedException();
    }

    internal void Edit(Keep keep)
    {
      throw new NotImplementedException();
    }

    internal void Remove(int keepId)
    {
      throw new NotImplementedException();
    }
  }
}