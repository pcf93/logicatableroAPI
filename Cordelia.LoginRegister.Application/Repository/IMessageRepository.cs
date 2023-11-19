using Cordelia.LoginRegister.Application.Services.Implementation;
using Cordelia.LoginRegister.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Cordelia.LoginRegister.Application.Repository;

public interface IMessageRepository
{
    /// <summary>
    /// Returns the User table from the database
    /// </summary>
    /// <returns></returns>
    public DbSet<Message> GetMessageContext();

}
