﻿using Enfonsalaflota.Application.DTO;
using Enfonsalaflota.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfonsalaflota.Application.Services.Abstraction
{
    public interface IMatchService
    {

        Task<Match> GetMatchByIdAsync(int id);


        Task<Match> GetMatchmakingMatch();

        Task<List<Match>> GetActiveMatchesByUserIdAsync(int id);

        Task<Match> CreateMatchmakingMatch(MatchCreateDto newMatch);

        Task<Match> JoinMatchmakingMatch(MatchJoinDto matchToJoin);

        Task<bool> ShootCoordinateAsync(int index, int matchId, int attackerId);

    }
}
