using Enfonsalaflota.Application.DTO;
using Enfonsalaflota.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfonsalaflota.Application.Services.Abstraction
{
    public interface IFriendRequestService
    {

        Task<List<FriendRequest>> GetFriendRequestsByUserId(int id);

        Task<List<FriendRequest>> GetFriendsByUserId(int id);

        Task<FriendRequest?> InsertFriendRequest(FriendRequestInsertDto friendRequest);

        Task<FriendRequest> AcceptFriendRequestAsync(int friendRequestId);

        Task<FriendRequest> RefuseFriendRequestAsync(int friendRequestId);
    }
}
