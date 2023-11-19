using Cordelia.LoginRegister.Application.Repository;
using Cordelia.LoginRegister.Domain.Model;
using Cordelia.LoginRegister.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cordelia.LoginRegister.Infraestructure.Repository;

public class MessageRepository : IMessageRepository
{

    private readonly ApplicationContext _dbContext;

    public MessageRepository (ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public DbSet<Message> GetMessageContext()
    {
        return _dbContext.Message;
    }

}
