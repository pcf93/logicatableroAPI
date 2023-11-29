using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfonsalaflota.Application.DTO;

public class MatchMessageInsertDto
{

    public int MessageSenderId { get; set; }

    public int MatchId { get; set; }

    public string MatchMessageContent { get; set; } = string.Empty;

}
