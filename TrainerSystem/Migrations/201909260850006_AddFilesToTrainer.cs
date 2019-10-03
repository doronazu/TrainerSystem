namespace TrainerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFilesToTrainer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainerId = c.Int(nullable: false),
                        Type = c.String(),
                        FilePath = c.String(),
                        DateTimeAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.TrainerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppFiles", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.AppFiles", new[] { "TrainerId" });
            DropTable("dbo.AppFiles");
        }
    }
}
