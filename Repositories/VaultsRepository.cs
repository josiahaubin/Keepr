using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(Vault newVault)
    {
      string sql = @"
        INSERT INTO vaults
        (name, description, userId)
        VALUES
        (@Name, @Description, @UserId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    public IEnumerable<Vault> Get(string userId)
    {
      string sql = "SELECT * FROM vaults WHERE userId = @userId";
      return _db.Query<Vault>(sql, new { userId });
    }
    public Vault Get(int vaultId)
    {
      string sql = "SELECT * FROM vaults WHERE id = @vaultId";
      return _db.QueryFirstOrDefault<Vault>(sql, new { vaultId });
    }

    public void Edit(Vault vault)
    {
      string sql = @"
      UPDATE vaults
      SET
        name = @Name,
        descritpion = @Description
      WHERE id = @Id";
      _db.Execute(sql, vault);
    }

    public void Remove(int vaultId)
    {
      string sql = "DELETE FROM vaults WHERE id = @vaultId";
      _db.Execute(sql, new { vaultId });
    }
  }
}