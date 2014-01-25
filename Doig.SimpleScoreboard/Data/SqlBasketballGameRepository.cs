using System;
using System.Collections.Generic;
using System.Linq;

namespace Doig.SimpleScoreboard.Data
{
    public class SqlBasketballGameRepository : Domain.IBasketballGameRepository
    {
        public Domain.BasketballGame Create(Domain.BasketballGame game)
        {
            if (game == null)
            {
                throw new ArgumentNullException("game");
            }
            using (var context = new ApplicationDbContext())
            {
                context.BasketballGames.Add(game);
                context.SaveChanges();
                return game;
            }
        }

        public Domain.BasketballGame GetForSport(string sport)
        {
            if (sport == null)
            {
                throw new ArgumentNullException("sport");
            }
            using (var context = new ApplicationDbContext())
            {
                var query = (from o in context.BasketballGames
                             where o.Sport == sport
                             select o);
                return query.SingleOrDefault();
            }
        }


        public Domain.BasketballGame Update(Domain.BasketballGame game)
        {
            using (var context = new ApplicationDbContext())
            {
                var exists = context.BasketballGames.First(o => o.Id == game.Id);
                exists.HomeScore = game.HomeScore;
                exists.HomeTeam = game.HomeTeam;
                exists.Sport = game.Sport;
                exists.Status = game.Status;
                exists.VisitingScore = game.VisitingScore;
                exists.VisitingTeam = game.VisitingTeam;
                context.SaveChanges();
                return game;
            }
        }
    }
} 