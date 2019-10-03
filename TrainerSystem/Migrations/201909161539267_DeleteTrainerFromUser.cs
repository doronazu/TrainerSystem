namespace TrainerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTrainerFromUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.AspNetUsers", new[] { "TrainerId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.AspNetUsers", "TrainerId");
            AddForeignKey("dbo.AspNetUsers", "TrainerId", "dbo.Trainers", "Id", cascadeDelete: true);
        }
    }
}
