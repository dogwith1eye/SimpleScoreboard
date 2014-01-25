using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doig.SimpleScoreboard.Domain
{
    public class BasketballGame
    {
        public int Id { get; set; }

        public string VisitingTeam { get; set; }

        public int VisitingScore { get; set; }

        public string HomeTeam { get; set; }

        public int HomeScore { get; set; }

        public string Status { get; set; }

        public string Sport { get; set; }
    }
}