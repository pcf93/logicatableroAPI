using Enfonsalaflota.Application.DTO;
using Enfonsalaflota.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfonsalaflota.Application.Services.Abstraction;

public interface IMatchMessageService
{
    Task<MatchMessage> GetLastReceivedMatchMessageAsync(int matchId, int userReceiverId);
    Task<List<MatchMessage>> GetMatchMessagesByMatchIdAsync(int matchId);
    Task<MatchMessage> SendNewMatchMessageAsync(MatchMessageInsertDto message);
}
