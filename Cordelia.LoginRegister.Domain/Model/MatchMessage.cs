using Cordelia.LoginRegister.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfonsalaflota.Domain.Model;

public class MatchMessage
{
    public int MatchMessageId { get; set; }

    public int MessageSenderId { get; set; }

    public int MatchId { get; set; }

    public string MatchMessageContent { get; set; } = string.Empty;

    public User MessageSender { get; set; }

    public Match Match { get; set; }

}
