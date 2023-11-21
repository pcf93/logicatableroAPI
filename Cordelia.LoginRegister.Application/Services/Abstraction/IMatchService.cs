using Enfonsalaflota.Application.DTO;
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

        Task<Match> GetMatchmakingMatch();

        Task<Match> CreateMatchmakingMatch(MatchCreateDto newMatch);

    }
}
