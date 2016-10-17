namespace Draughts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompleteRebuild : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BoardSetups", "BoardSetup_PositionID", "dbo.BoardSetups");
            DropIndex("dbo.BoardSetups", new[] { "BoardSetup_PositionID" });
            CreateTable(
                "dbo.GameInfoes",
                c => new
                    {
                        gameInfoId = c.Int(nullable: false, identity: true),
                        gameNumber = c.Int(nullable: false),
                        turn = c.Int(nullable: false),
                        GameInfo_gameInfoId = c.Int(),
                    })
                .PrimaryKey(t => t.gameInfoId)
                .ForeignKey("dbo.GameInfoes", t => t.GameInfo_gameInfoId)
                .Index(t => t.GameInfo_gameInfoId);
            
            CreateTable(
                "dbo.GameInfoHistories",
                c => new
                    {
                        GameHistoryID = c.Int(nullable: false, identity: true),
                        Winner = c.Int(nullable: false),
                        gameinfo_gameInfoId = c.Int(),
                        GameInfoHistory_GameHistoryID = c.Int(),
                    })
                .PrimaryKey(t => t.GameHistoryID)
                .ForeignKey("dbo.GameInfoes", t => t.gameinfo_gameInfoId)
                .ForeignKey("dbo.GameInfoHistories", t => t.GameInfoHistory_GameHistoryID)
                .Index(t => t.gameinfo_gameInfoId)
                .Index(t => t.GameInfoHistory_GameHistoryID);
            
            DropTable("dbo.BoardSetups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BoardSetups",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        BoardSetup_PositionID = c.Int(),
                    })
                .PrimaryKey(t => t.PositionID);
            
            DropForeignKey("dbo.GameInfoHistories", "GameInfoHistory_GameHistoryID", "dbo.GameInfoHistories");
            DropForeignKey("dbo.GameInfoHistories", "gameinfo_gameInfoId", "dbo.GameInfoes");
            DropForeignKey("dbo.GameInfoes", "GameInfo_gameInfoId", "dbo.GameInfoes");
            DropIndex("dbo.GameInfoHistories", new[] { "GameInfoHistory_GameHistoryID" });
            DropIndex("dbo.GameInfoHistories", new[] { "gameinfo_gameInfoId" });
            DropIndex("dbo.GameInfoes", new[] { "GameInfo_gameInfoId" });
            DropTable("dbo.GameInfoHistories");
            DropTable("dbo.GameInfoes");
            CreateIndex("dbo.BoardSetups", "BoardSetup_PositionID");
            AddForeignKey("dbo.BoardSetups", "BoardSetup_PositionID", "dbo.BoardSetups", "PositionID");
        }
    }
}
