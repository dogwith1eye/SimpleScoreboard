using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Doig.SimpleScoreboard.Models
{
    // Models used as parameters to GameController actions.

    public class SaveBasketballGameBindingModel
    {
        [Required]
        [Display(Name = "Visiting Team")]
        public string VisitingTeam { get; set; }

        [Display(Name = "Visiting Score")]
        public int VisitingScore { get; set; }

        [Required]
        [Display(Name = "Home Team")]
        public string HomeTeam { get; set; }

        [Display(Name = "Visiting Score")]
        public int HomeScore { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Sport")]
        public string Sport { get; set; }
    }
}
