using Cordelia.LoginRegister.Application.DTO;
using Cordelia.LoginRegister.Application.Repository;
using Cordelia.LoginRegister.Application.Services.Abstraction;
using Cordelia.LoginRegister.Domain.Model;

namespace Cordelia.LoginRegister.Application.Services.Implementation;

public class MessageService : IMessageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Message> _messageRepository;

    public MessageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _messageRepository = unitOfWork.GetMessageRepository();

    }

    public async Task<List<Message>> GetAllMessages()
    {
        var messages = await _messageRepository.GetAsync();

        return await Task.FromResult(messages.ToList());
    }

    public async Task<List<Message>> GetMessagesReceivedById(int id)
    {
        var messages = await _messageRepository.GetAsync( message => message.MessageReceiverId == id);

        return await Task.FromResult(messages.ToList());
    }

    public async Task<List<Message>> GetMessagesSentById(int id)
    {
        var messages = await _messageRepository.GetAsync(message => message.MessageSenderId == id);

        return await Task.FromResult(messages.ToList());
    }

    public async Task<Message> InsertMessage(MessageInsertDto message)
    {

        var messageToInsert = new Message()
        {
            MessageSenderId = message.MessageSenderId,
            MessageReceiverId = message.MessageReceiverId,
            MessageContent = message.MessageContent,
            MessageDate = DateTime.Now,
            MessageSubject = message.MessageSubject,
            IsRead = false,
        };

        await _messageRepository.InsertAsync(messageToInsert);
        await _unitOfWork.SaveAsync();

        return await Task.FromResult(messageToInsert);
    }

    public async Task<Message> ChangeStatusAsync(int messageId)
    {

        var message = await _messageRepository.GetByIdAsync(messageId);

        message.IsRead = true;

        _messageRepository.Update(message);
        await _unitOfWork.SaveAsync();

        return await Task.FromResult(message);

    }

    public async Task<Message> DeleteMessageAsync(int messageId)
    {
        var message = await _messageRepository.GetByIdAsync(messageId);

        _messageRepository.Delete(message);
        await _unitOfWork.SaveAsync();

        return await Task.FromResult(message);
    }

}

