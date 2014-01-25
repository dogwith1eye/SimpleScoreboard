using System;
using System.Collections.Generic;

namespace Doig.SimpleScoreboard.Domain
{
    public interface IBasketballGameRepository
    {
        BasketballGame Create(BasketballGame game);
        BasketballGame GetForSport(string sport);
        BasketballGame Update(BasketballGame game);
    }
}

