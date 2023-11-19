using Cordelia.LoginRegister.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfonsalaflota.Domain.Model;

public class FriendRequest
{
    public int FriendRequestId { get; set; }

    public int FriendRequestSenderId { get; set; }

    public int FriendRequestReceiverId { get; set; }

    public FriendRequestStatus Status { get; set; }

    public User FriendRequestSender { get; set; }

    public User FriendRequestReceiver { get; set; }
}

public enum FriendRequestStatus
{
    Pendent,
    Acceptada,
    Rebutjada
}
