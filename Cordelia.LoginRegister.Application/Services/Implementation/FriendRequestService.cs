using Cordelia.LoginRegister.Application.DTO;
using Cordelia.LoginRegister.Application.Repository;
using Cordelia.LoginRegister.Application.Services.Abstraction;
using Cordelia.LoginRegister.Domain.Model;
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
    public class FriendRequestService : IFriendRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<FriendRequest> _friendRequestRepository;

        public FriendRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _friendRequestRepository = unitOfWork.GetFriendRequestRepository();

        }

        public async Task<List<FriendRequest>> GetFriendRequestsByUserId (int id)
        {
            var requests = await _friendRequestRepository.GetAsync(x => (x.FriendRequestSenderId == id || x.FriendRequestReceiverId == id) && x.Status == FriendRequestStatus.Pendent);

            return await Task.FromResult(requests.ToList());

        }

        public async Task<List<FriendRequest>> GetFriendsByUserId(int id)
        {
            var requests = await _friendRequestRepository.GetAsync(x => (x.FriendRequestSenderId == id || x.FriendRequestReceiverId == id) && x.Status == FriendRequestStatus.Acceptada);

            return await Task.FromResult(requests.ToList());

        }

        public async Task<FriendRequest?> InsertFriendRequest(FriendRequestInsertDto friendRequest)
        {

            var exists = await _friendRequestRepository
                .GetAsync(x => (x.FriendRequestSenderId == friendRequest.FriendRequestSenderId && x.FriendRequestReceiverId == friendRequest.FriendRequestReceiverId) ||
                (x.FriendRequestSenderId == friendRequest.FriendRequestReceiverId && x.FriendRequestReceiverId == friendRequest.FriendRequestSenderId));

            if (exists.FirstOrDefault() != null)
            {

                return null;

            } else {

                var friendRequestToInsert = new FriendRequest()
                {
                    FriendRequestSenderId = friendRequest.FriendRequestSenderId,
                    FriendRequestReceiverId = friendRequest.FriendRequestReceiverId,
                    Status = FriendRequestStatus.Pendent

                };

                await _friendRequestRepository.InsertAsync(friendRequestToInsert);
                await _unitOfWork.SaveAsync();

                return await Task.FromResult(friendRequestToInsert);

            }
            
            
        }

        public async Task<FriendRequest> AcceptFriendRequestAsync(int friendRequestId)
        {

            var friendRequest = await _friendRequestRepository.GetByIdAsync(friendRequestId);

            friendRequest.Status = FriendRequestStatus.Acceptada;

            _friendRequestRepository.Update(friendRequest);
            await _unitOfWork.SaveAsync();

            return await Task.FromResult(friendRequest);

        }
    }
}
