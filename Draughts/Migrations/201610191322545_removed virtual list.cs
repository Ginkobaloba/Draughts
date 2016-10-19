namespace Draughts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedvirtuallist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameInfoes", "GameInfo_gameInfoId", "dbo.GameInfoes");
            DropIndex("dbo.GameInfoes", new[] { "GameInfo_gameInfoId" });
            DropColumn("dbo.GameInfoes", "GameInfo_gameInfoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameInfoes", "GameInfo_gameInfoId", c => c.Int());
            CreateIndex("dbo.GameInfoes", "GameInfo_gameInfoId");
            AddForeignKey("dbo.GameInfoes", "GameInfo_gameInfoId", "dbo.GameInfoes", "gameInfoId");
        }
    }
}
