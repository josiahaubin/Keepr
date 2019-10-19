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
  public class VaultsController : ControllerBase
  {

    private readonly VaultsService _vs;
    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }

    [Authorize]
    [HttpGet] //NOTE This route gets user vaults
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.Get(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpGet("{vaultId}")] //NOTE This route gets a vault by its id
    public ActionResult<Vault> Get(int vaultId)
    {
      try
      {
        return Ok(_vs.Get(vaultId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost] //NOTE This route creates a new vault
    public ActionResult<Vault> Post([FromBody] Vault newVault)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.Create(newVault, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut("{vaultId}")] //NOTE This route updates a vault
    public ActionResult<Vault> Put(int vaultId, [FromBody] Vault editVault)
    {
      try
      {
        editVault.Id = vaultId;
        return Ok(_vs.Edit(editVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{vaultId}")] //NOTE This route deletes a vault
    public ActionResult<string> Delete(int vaultId)
    {
      try
      {
        return Ok(_vs.Remove(vaultId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}