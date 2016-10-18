namespace Draughts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fresh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameInfoes",
                c => new
                    {
                        gameInfoId = c.Int(nullable: false, identity: true),
                        gameNumber = c.Int(nullable: false),
                        turn = c.Int(nullable: false),
                        square1 = c.Int(nullable: false),
                        square3 = c.Int(nullable: false),
                        square5 = c.Int(nullable: false),
                        square7 = c.Int(nullable: false),
                        square10 = c.Int(nullable: false),
                        square12 = c.Int(nullable: false),
                        square14 = c.Int(nullable: false),
                        square16 = c.Int(nullable: false),
                        square17 = c.Int(nullable: false),
                        square19 = c.Int(nullable: false),
                        square21 = c.Int(nullable: false),
                        square23 = c.Int(nullable: false),
                        square26 = c.Int(nullable: false),
                        square28 = c.Int(nullable: false),
                        square30 = c.Int(nullable: false),
                        square32 = c.Int(nullable: false),
                        square33 = c.Int(nullable: false),
                        square35 = c.Int(nullable: false),
                        square37 = c.Int(nullable: false),
                        square39 = c.Int(nullable: false),
                        square42 = c.Int(nullable: false),
                        square44 = c.Int(nullable: false),
                        square46 = c.Int(nullable: false),
                        square48 = c.Int(nullable: false),
                        square49 = c.Int(nullable: false),
                        square51 = c.Int(nullable: false),
                        square53 = c.Int(nullable: false),
                        square55 = c.Int(nullable: false),
                        square58 = c.Int(nullable: false),
                        square60 = c.Int(nullable: false),
                        square62 = c.Int(nullable: false),
                        square64 = c.Int(nullable: false),
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
                        GameInfoID = c.Int(nullable: false),
                        GameInfoHistory_GameHistoryID = c.Int(),
                    })
                .PrimaryKey(t => t.GameHistoryID)
                .ForeignKey("dbo.GameInfoes", t => t.GameInfoID, cascadeDelete: true)
                .ForeignKey("dbo.GameInfoHistories", t => t.GameInfoHistory_GameHistoryID)
                .Index(t => t.GameInfoID)
                .Index(t => t.GameInfoHistory_GameHistoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameInfoHistories", "GameInfoHistory_GameHistoryID", "dbo.GameInfoHistories");
            DropForeignKey("dbo.GameInfoHistories", "GameInfoID", "dbo.GameInfoes");
            DropForeignKey("dbo.GameInfoes", "GameInfo_gameInfoId", "dbo.GameInfoes");
            DropIndex("dbo.GameInfoHistories", new[] { "GameInfoHistory_GameHistoryID" });
            DropIndex("dbo.GameInfoHistories", new[] { "GameInfoID" });
            DropIndex("dbo.GameInfoes", new[] { "GameInfo_gameInfoId" });
            DropTable("dbo.GameInfoHistories");
            DropTable("dbo.GameInfoes");
        }
    }
}
