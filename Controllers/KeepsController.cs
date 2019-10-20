using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [HttpGet("user")] //NOTE This route gets all keeps by the logged in user
    public ActionResult<IEnumerable<Keep>> GetUserKeeps()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.GetUserKeeps(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{keepId}")] //NOTE This route gets a single keep
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

    [Authorize]
    [HttpPost] //NOTE This route creates a new keep
    public ActionResult<Keep> Post([FromBody] Keep newKeep)
    {
      try
      {
        string id = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.Create(newKeep, id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
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

    [Authorize]
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