using Cordelia.LoginRegister.Application.Repository;
using Cordelia.LoginRegister.Application.Services.Abstraction;
using Enfonsalaflota.Application.DTO;
using Enfonsalaflota.Application.Services.Abstraction;
using Enfonsalaflota.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfonsalaflota.Application.Services.Implementation;

public class MatchMessageService : IMatchMessageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<MatchMessage> _matchMessageRepository;

    public MatchMessageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _matchMessageRepository = unitOfWork.GetMatchMessageRepository();
    }

    public async Task<List<MatchMessage>> GetMatchMessagesByMatchIdAsync( int matchId )
    {

        var matchMessages = await _matchMessageRepository.GetAsync(x => x.MatchId == matchId);

        return matchMessages.ToList();

    }

    public async Task<MatchMessage> GetLastReceivedMatchMessageAsync( int matchId, int userReceiverId)
    {
        var matchMessages = await _matchMessageRepository.GetAsync(x => x.MatchId == matchId && x.MessageSenderId != userReceiverId);

        return matchMessages.LastOrDefault();
    }

    public async Task<MatchMessage> SendNewMatchMessageAsync(MatchMessageInsertDto message)
    {
        var messageToInsert = new MatchMessage()
        {
            MessageSenderId = message.MessageSenderId,
            MatchId = message.MatchId,
            MatchMessageContent = message.MatchMessageContent
        };

        await _matchMessageRepository.InsertAsync(messageToInsert);
        await _unitOfWork.SaveAsync();

        return await Task.FromResult(messageToInsert);
    }

}
