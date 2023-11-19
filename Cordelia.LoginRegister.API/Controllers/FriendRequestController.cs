using Cordelia.LoginRegister.Application.Services.Abstraction;
using Cordelia.LoginRegister.Domain.Model;
using Enfonsalaflota.Application.DTO;
using Enfonsalaflota.Application.Services.Abstraction;
using Enfonsalaflota.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enfonsalaflota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendRequestController : ControllerBase
    {
        private readonly IFriendRequestService _service;

        public FriendRequestController(IFriendRequestService service) { _service = service; }

        [HttpGet]
        [Route("friendRequests/{id}")]

        public async Task<ActionResult<List<FriendRequest>>> GetFriendRequestsById(int id)
        {
            var result = await _service.GetFriendRequestsByUserId(id);

            if (result.Count == 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("friends/{id}")]

        public async Task<ActionResult<List<FriendRequest>>> GetFriendsById(int id)
        {
            var result = await _service.GetFriendsByUserId(id);

            if (result.Count == 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("addFriendRequest")]

        public async Task<ActionResult<FriendRequest>> InsertFriendRequest(FriendRequestInsertDto friendRequest)
        {
            var result = await _service.InsertFriendRequest(friendRequest);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("accept/{friendRequestId}")]

        public async Task<ActionResult<FriendRequest>> ChangeStatusToAccept(int friendRequestId)
        {
            var result = await _service.AcceptFriendRequestAsync(friendRequestId);

            if (result is null) { return BadRequest(); }

            return Ok(result);

        }


    }

}


