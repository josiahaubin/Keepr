using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }

    [HttpGet] //NOTE This route gets public keeps
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("/user")] //NOTE This route gets all keeps by the logged in user
    public ActionResult<IEnumerable<Keep>> GetUserKeeps()
    {
      try
      {
        return Ok(_ks.GetUserKeeps());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{keepId}")]
    public ActionResult<Keep> Get(int keepId)
    {
      try
      {
        return Ok(_ks.Get(keepId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost] //NOTE This route creats a new keep
    public ActionResult<Keep> Post([FromBody] Keep newKeep)
    {
      try
      {
        return Ok(_ks.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{keepId}")] //NOTE This route updates a keep
    public ActionResult<Keep> Put(int keepId, [FromBody] Keep editKeep)
    {
      try
      {
        editKeep.Id = keepId;
        return Ok(_ks.Edit(editKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{keepId}")] //NOTE This route deletes a keep
    public ActionResult<string> Delete(int keepId)
    {
      try
      {
        return Ok(_ks.Remove(keepId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



  }
}