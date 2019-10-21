using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
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

    public IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM keeps";
      return _db.Query<Keep>(sql);
    }

    public IEnumerable<Keep> GetUserKeeps(string userId)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @userId";
      return _db.Query<Keep>(sql, new { userId });
    }

    public Keep Get(int keepId)
    {
      string sql = "SELECT * FROM keeps WHERE id = @keepId";
      return _db.QueryFirstOrDefault<Keep>(sql, new { keepId });
    }

    public int Create(Keep newKeep)
    {
      string sql = @"
        INSERT INTO keeps
        (name, description, img, isPrivate, views, shares, keeps, userId)
        VALUES
        (@Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps, @UserId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    public void Edit(Keep keep)
    {
      string sql = @"
        UPDATE keeps
        SET
          name = @Name,
          description = @Description,
          img = @Img,
          isPrivate = @IsPrivate,
          views = @Views,
          shares = @Shares,
          keeps = @Keeps
        WHERE id = @Id";
      _db.Execute(sql, keep);
    }

    public void Remove(int keepId, string userId)
    {
      string sql = "DELETE FROM keeps WHERE id = @keepId AND userId = @userId";
      _db.Execute(sql, new { keepId, userId });
    }
  }
}