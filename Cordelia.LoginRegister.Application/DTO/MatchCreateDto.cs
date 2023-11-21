using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfonsalaflota.Application.DTO;

public class MatchCreateDto
{ 

    public int Player1Id { get; set; }

    public int Player2Id { get; set; }

    public int[] ArrayPlayer1 { get; set; }

}
