using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doig.SimpleScoreboard.Domain
{
    public class BasketballGameService : IBasketballGameService
    {
        private readonly IBasketballGameRepository repository;

        public BasketballGameService(IBasketballGameRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            this.repository = repository;
        }

        public BasketballGame Save(BasketballGame game)
        {
            var trysport = TryGetForSport(game.Sport);
            if (trysport.Item1)
            {
                game.Id = trysport.Item2.Id;
                return this.repository.Update(game);
            }
            else
            {
                return this.repository.Create(game);
            }
        }
        
        public Tuple<bool, BasketballGame> TryGetForSport(string sport)
        {
            var found = repository.GetForSport(sport);
            return new Tuple<bool, BasketballGame>(found != null, found);
        }
    }
}