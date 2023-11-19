using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfonsalaflota.Application.DTO
{
    public class FriendRequestInsertDto
    {
        public int FriendRequestSenderId { get; set; }

        public int FriendRequestReceiverId { get; set; }
    }
}
