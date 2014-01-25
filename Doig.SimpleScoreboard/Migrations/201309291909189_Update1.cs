namespace Doig.SimpleScoreboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketballGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitingTeam = c.String(),
                        VisitingScore = c.Int(nullable: false),
                        HomeTeam = c.String(),
                        HomeScore = c.Int(nullable: false),
                        Status = c.String(),
                        Sport = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.BasketballGames");
        }
    }
}
