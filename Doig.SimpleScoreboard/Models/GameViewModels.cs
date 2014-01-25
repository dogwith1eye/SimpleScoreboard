using System;
using System.Collections.Generic;

namespace Doig.SimpleScoreboard.Models
{
    // Models returned by GameController actions.

    public class BasketballGameViewModel
    {
        public string VisitingTeam { get; set; }

        public int VisitingScore { get; set; }

        public string HomeTeam { get; set; }

        public int HomeScore { get; set; }

        public string Status { get; set; }

        public string Sport { get; set; }
    }
}
