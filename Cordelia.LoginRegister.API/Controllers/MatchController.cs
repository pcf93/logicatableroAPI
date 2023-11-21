using Enfonsalaflota.Application.Services.Abstraction;
using Enfonsalaflota.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enfonsalaflota.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatchController : ControllerBase
{
    private readonly IMatchService _service;

    public MatchController(IMatchService service) { _service = service; }

    [HttpGet]
    [Route("findMatchmaking")]
    public async Task<ActionResult<Match>> FindMatchmakingMatch(int id)
    {
        var result = await _service.GetMatchmakingMatch();

        if (result is null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

}
