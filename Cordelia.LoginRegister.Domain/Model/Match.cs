using Cordelia.LoginRegister.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfonsalaflota.Domain.Model;

public class Match
{
    public int MatchId { get; set; }

    public int Player1Id { get; set; }

    public int Player2Id { get; set; }

    public int[] ArrayPlayer1 { get; set; }

    public int[] ArrayPlayer2 { get; set; }

    public MatchStatus MatchStatus { get; set; }

    public MatchStartType MatchStartType { get; set; }

    public User Player1 { get; set; }

    public User Player2 { get; set; }
}

public enum MatchStatus
{
    Pendent,
    Iniciat,
    Acabat
}

public enum MatchStartType
{
    IA,
    Matchmaking,
    Amic
}
