using Cordelia.LoginRegister.Application.Repository;
using Cordelia.LoginRegister.Domain.Model;
using Enfonsalaflota.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordelia.LoginRegister.Application.Services.Abstraction;

public interface IUnitOfWork : IDisposable
{
    public IGenericRepository<User> GetUserRepository();
    public IGenericRepository<Message> GetMessageRepository();

    public IGenericRepository<FriendRequest> GetFriendRequestRepository();

    public Task SaveAsync();

}
