using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Vault> Get(string userId)
    {
      return _repo.Get(userId);
    }
    public Vault Get(int vaultId)
    {
      Vault exists = _repo.Get(vaultId);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }

    public Vault Create(Vault newVault, string userId)
    {
      newVault.UserId = userId;
      int id = _repo.Create(newVault);
      newVault.Id = id;
      return newVault;
    }

    public Vault Edit(Vault editVault)
    {
      Vault vault = _repo.Get(editVault.Id);
      if (vault == null) { throw new Exception("Invalid ID"); }
      vault.Name = editVault.Name;
      vault.Description = editVault.Description;
      _repo.Edit(vault);
      return vault;
    }

    [Authorize]
    public string Remove(int vaultId)
    {
      Vault exists = _repo.Get(vaultId);
      if (exists == null) { throw new Exception("Invalid ID"); }
      _repo.Remove(vaultId);
      return "Successfully Removed.";
    }
  }
}