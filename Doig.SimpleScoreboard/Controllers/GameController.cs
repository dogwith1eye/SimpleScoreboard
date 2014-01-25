using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Doig.SimpleScoreboard.Models;
using Doig.SimpleScoreboard.Providers;
using Doig.SimpleScoreboard.Results;
using Doig.SimpleScoreboard.Domain;
using Doig.SimpleScoreboard.Data;
using Microsoft.AspNet.SignalR;
using Doig.SimpleScoreboard.Hubs;
using System.Web.Http.Cors;

namespace Doig.SimpleScoreboard.Controllers
{
    [RoutePrefix("api/Game")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GameController : ApiController
    {
        public GameController()
        {
        }

        // GET api/Game/BasketballGame
        [HttpGet("BasketballGame")]
        public BasketballGameViewModel BasketballGame(string sport)
        {
            var repository = new SqlBasketballGameRepository();
            var service = new BasketballGameService(repository);
            var game = service.TryGetForSport(sport);
            if (game.Item1)
            {
                return new BasketballGameViewModel()
                {
                    HomeScore = game.Item2.HomeScore,
                    HomeTeam = game.Item2.HomeTeam,
                    Sport = game.Item2.Sport,
                    Status = game.Item2.Status,
                    VisitingScore = game.Item2.VisitingScore,
                    VisitingTeam = game.Item2.VisitingTeam
                };
            }
            else
            {
                return new BasketballGameViewModel()
                {
                    HomeScore = 0,
                    HomeTeam = "",
                    Sport = "",
                    Status = "",
                    VisitingScore = 0,
                    VisitingTeam = ""
                };
            }
        }

        // POST api/Game/SaveBasketballGame
        [HttpPost("SaveBasketballGame")]
        public async Task<IHttpActionResult> SaveBasketballGame(SaveBasketballGameBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var repository = new SqlBasketballGameRepository();
            var service = new BasketballGameService(repository);
            var game = new BasketballGame()
            {
                HomeScore = model.HomeScore,
                HomeTeam = model.HomeTeam,
                Sport = model.Sport,
                Status = model.Status,
                VisitingScore = model.VisitingScore,
                VisitingTeam = model.VisitingTeam
            };
            service.Save(game);
            var gamevm = new BasketballGameViewModel()
            {
                HomeScore = game.HomeScore,
                HomeTeam = game.HomeTeam,
                Sport = game.Sport,
                Status = game.Status,
                VisitingScore = game.VisitingScore,
                VisitingTeam = game.VisitingTeam
            };
            var context = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
            context.Clients.All.basketballGameSaved(gamevm);

            return Ok();
        }
    }
}
