﻿using Cordelia.LoginRegister.Application.Repository;
using Cordelia.LoginRegister.Application.Services.Abstraction;
using Enfonsalaflota.Application.DTO;
using Enfonsalaflota.Application.Services.Abstraction;
using Enfonsalaflota.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfonsalaflota.Application.Services.Implementation
{
    public class MatchService : IMatchService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Match> _matchRepository;

        public MatchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _matchRepository = unitOfWork.GetMatchRepository();

        }

        public async Task<Match> GetMatchmakingMatch()
        {

            var match = await _matchRepository.GetAsync(x => x.MatchStartType == MatchStartType.Matchmaking && x.ArrayPlayer2 == null);

            return await Task.FromResult(match.FirstOrDefault());

        }

        public async Task<Match> CreateMatchmakingMatch(MatchCreateDto newMatch)
        {
            var matchToCreate = new Match()
            {
                Player1Id = newMatch.Player1Id,
                ArrayPlayer1 = newMatch.ArrayPlayer1,
                Player2Id = newMatch.Player1Id,
                MatchStatus = MatchStatus.Pendent,
                MatchStartType = MatchStartType.Matchmaking

            };

            await _matchRepository.InsertAsync(matchToCreate);
            await _unitOfWork.SaveAsync();

            return await Task.FromResult(matchToCreate);
        }

        public async Task<Match> JoinMatchmakingMatch(MatchJoinDto matchToJoin)
        {

            var matchResult = await _matchRepository.GetAsync(x => x.MatchStartType == MatchStartType.Matchmaking && x.ArrayPlayer2 == null);

            var match = matchResult.FirstOrDefault();

            match.ArrayPlayer2 = matchToJoin.ArrayPlayer2;
            match.Player2Id = matchToJoin.Player2Id;
            match.MatchStatus = MatchStatus.Iniciat;

            _matchRepository.Update(match);
            await _unitOfWork.SaveAsync();

            return await Task.FromResult(match);

        }

    }
}
