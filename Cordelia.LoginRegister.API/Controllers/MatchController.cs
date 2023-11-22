﻿using Enfonsalaflota.Application.DTO;
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

    [HttpGet]
    [Route("getActiveMatches/{id}")]
    public async Task<ActionResult<List<Match>>> GetMatchesById(int id)
    {
        var result = await _service.GetActiveMatchesByUserIdAsync(id);

        if (result is null)
        {
            return BadRequest();
        }

        return Ok(result);
    }
    
    [HttpPost]
    [Route("createMatchmaking")]
    public async Task<ActionResult<Match>> CreateMatchmakingMatch(MatchCreateDto newMatch)
    {
        var result = await _service.CreateMatchmakingMatch(newMatch);

        if (result is null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPut]
    [Route("joinMatchmaking")]

    public async Task<ActionResult<Match>> JoinMatchmakingMatch(MatchJoinDto matchToJoin)
    {
        var result = await _service.JoinMatchmakingMatch(matchToJoin);

        if (result is null)
        {
            return BadRequest();
        }

        return Ok(result);

    }


}
