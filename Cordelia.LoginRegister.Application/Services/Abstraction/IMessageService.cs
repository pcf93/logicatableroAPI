using Cordelia.LoginRegister.Application.DTO;
using Cordelia.LoginRegister.Domain.Model;

namespace Cordelia.LoginRegister.Application.Services.Abstraction;

public interface IMessageService
{

    Task<List<Message>> GetAllMessages();

    Task <List<Message>> GetMessagesReceivedById (int id);
   
    Task <List<Message>> GetMessagesSentById(int id);

    Task<Message> InsertMessage(MessageInsertDto message);

    Task<Message> ChangeStatusAsync(int messageId);

    Task<Message> DeleteMessageAsync(int messageId);

}
