using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {

    }
  }
}