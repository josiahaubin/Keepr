using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> Get(int vaultId, string userId)
    {
      string sql = @"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE (vaultId = @vaultId AND vk.userId = @userId)";
      return _db.Query<Keep>(sql, new { vaultId, userId });
    }
    public VaultKeep Check(int vaultId, int keepId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE vaultId = @vaultId AND keepId = @keepId";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId, keepId });
    }
    public void Remove(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    public int Create(VaultKeep vaultKeep)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      (vaultId, keepId, userId)
      VALUES
      (@VaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, vaultKeep);
    }

  }
}