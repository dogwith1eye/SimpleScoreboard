using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Doig.SimpleScoreboard.Domain;

namespace Doig.SimpleScoreboard.Data
{
    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public DbSet<BasketballGame> BasketballGames { get; set; }
    }

    //public class ApplicationDbContext : DbContext
    //{
    //    public DbSet<BasketballGame> BasketballGames { get; set; }
    //}
}