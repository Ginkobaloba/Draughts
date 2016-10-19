namespace Draughts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameInfoHistories", "GameInfoID", "dbo.GameInfoes");
            DropForeignKey("dbo.GameInfoHistories", "GameInfoHistory_GameHistoryID", "dbo.GameInfoHistories");
            DropIndex("dbo.GameInfoHistories", new[] { "GameInfoID" });
            DropIndex("dbo.GameInfoHistories", new[] { "GameInfoHistory_GameHistoryID" });
            AddColumn("dbo.GameInfoes", "winner", c => c.Int());
            DropTable("dbo.GameInfoHistories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GameInfoHistories",
                c => new
                    {
                        GameHistoryID = c.Int(nullable: false, identity: true),
                        Winner = c.Int(nullable: false),
                        GameInfoID = c.Int(nullable: false),
                        GameInfoHistory_GameHistoryID = c.Int(),
                    })
                .PrimaryKey(t => t.GameHistoryID);
            
            DropColumn("dbo.GameInfoes", "winner");
            CreateIndex("dbo.GameInfoHistories", "GameInfoHistory_GameHistoryID");
            CreateIndex("dbo.GameInfoHistories", "GameInfoID");
            AddForeignKey("dbo.GameInfoHistories", "GameInfoHistory_GameHistoryID", "dbo.GameInfoHistories", "GameHistoryID");
            AddForeignKey("dbo.GameInfoHistories", "GameInfoID", "dbo.GameInfoes", "gameInfoId", cascadeDelete: true);
        }
    }
}
