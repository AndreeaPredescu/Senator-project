namespace Senator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigureSoldierRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Soldiers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Soldiers", "RankId", "dbo.Ranks");
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        TrainingId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TrainingId);
            
            AddColumn("dbo.Soldiers", "TrainingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Soldiers", "TrainingId");
            AddForeignKey("dbo.Soldiers", "TrainingId", "dbo.Trainings", "TrainingId");
            AddForeignKey("dbo.Soldiers", "CountryId", "dbo.Countries", "CountryId");
            AddForeignKey("dbo.Soldiers", "RankId", "dbo.Ranks", "RankId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Soldiers", "RankId", "dbo.Ranks");
            DropForeignKey("dbo.Soldiers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Soldiers", "TrainingId", "dbo.Trainings");
            DropIndex("dbo.Soldiers", new[] { "TrainingId" });
            DropColumn("dbo.Soldiers", "TrainingId");
            DropTable("dbo.Trainings");
            AddForeignKey("dbo.Soldiers", "RankId", "dbo.Ranks", "RankId", cascadeDelete: true);
            AddForeignKey("dbo.Soldiers", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
        }
    }
}
