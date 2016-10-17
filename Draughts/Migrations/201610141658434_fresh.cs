namespace Draughts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fresh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardSetups",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        BoardSetup_PositionID = c.Int(),
                    })
                .PrimaryKey(t => t.PositionID)
                .ForeignKey("dbo.BoardSetups", t => t.BoardSetup_PositionID)
                .Index(t => t.BoardSetup_PositionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BoardSetups", "BoardSetup_PositionID", "dbo.BoardSetups");
            DropIndex("dbo.BoardSetups", new[] { "BoardSetup_PositionID" });
            DropTable("dbo.BoardSetups");
        }
    }
}
