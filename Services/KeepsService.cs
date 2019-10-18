using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Http;

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
      return _repo.Get();
    }

    public IEnumerable<Keep> GetUserKeeps(string userId)
    {
      return _repo.Get();
    }
    public Keep Get(int keepId)
    {
      Keep exists = _repo.Get(keepId);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }
    public Keep Create(Keep newKeep)
    {
      int id = _repo.Create(newKeep);
      newKeep.Id = id;
      return newKeep;
    }
    public Keep Edit(Keep editKeep)
    {
      Keep keep = _repo.Get(editKeep.Id);
      if (keep == null) { throw new Exception("Invalid ID"); }
      keep.Img = editKeep.Img;
      keep.IsPrivate = editKeep.IsPrivate;
      keep.Keeps = editKeep.Keeps;
      keep.Name = editKeep.Name;
      keep.Shares = editKeep.Shares;
      keep.Views = editKeep.Views;
      _repo.Edit(keep);
      return keep;
    }
    public string Remove(int keepId)
    {
      Keep exists = _repo.Get(keepId);
      if (exists == null) { throw new Exception("Invalid ID"); }
      _repo.Remove(keepId);
      return "Successfully Removed.";
    }
  }
}