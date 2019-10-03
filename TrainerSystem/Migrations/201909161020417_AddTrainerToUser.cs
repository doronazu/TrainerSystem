namespace TrainerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrainerToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "TrainerId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "TrainerId");
            AddForeignKey("dbo.AspNetUsers", "TrainerId", "dbo.Trainers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.AspNetUsers", new[] { "TrainerId" });
            DropColumn("dbo.AspNetUsers", "TrainerId");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
