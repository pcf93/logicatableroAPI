using Cordelia.LoginRegister.Application.Services.Abstraction;
using Enfonsalaflota.Application.DTO;
using Enfonsalaflota.Application.Services.Abstraction;
using Enfonsalaflota.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enfonsalaflota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MatchMessageController : ControllerBase
    {

        private readonly IMatchMessageService _service;

        public MatchMessageController(IMatchMessageService service) { _service = service; }

        [HttpGet, Authorize]
        [Route("{matchId}")]

        public async Task<ActionResult<List<MatchMessage>>> GetMessagesByMatchId( int matchId)
        {
            var result = await _service.GetMatchMessagesByMatchIdAsync(matchId);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);

        }

        [HttpGet, Authorize]
        [Route("{matchId}/{userId}")]
        public async Task<ActionResult<MatchMessage>> GetLastMatchMessage (int userId, int matchId)
        {
            var result = await _service.GetLastReceivedMatchMessageAsync(matchId, userId);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost, Authorize]
        [Route("add")]
        public async Task<ActionResult<MatchMessage>> InsertMatchMessage (MatchMessageInsertDto message)
        {
            var result = await _service.SendNewMatchMessageAsync(message);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

    }
}
