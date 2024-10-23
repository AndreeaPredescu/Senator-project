namespace Senator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Soldiers",
                c => new
                    {
                        SoldierId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        CountryId = c.Int(nullable: false),
                        RankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SoldierId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Ranks", t => t.RankId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.RankId);
            
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        RankId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RankId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Soldiers", "RankId", "dbo.Ranks");
            DropForeignKey("dbo.Soldiers", "CountryId", "dbo.Countries");
            DropIndex("dbo.Soldiers", new[] { "RankId" });
            DropIndex("dbo.Soldiers", new[] { "CountryId" });
            DropTable("dbo.Ranks");
            DropTable("dbo.Soldiers");
            DropTable("dbo.Countries");
        }
    }
}
