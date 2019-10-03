namespace TrainerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomersToTrainer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainerId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        ContactName = c.String(),
                        ContactPhone = c.String(),
                        Email = c.String(),
                        HowYouGetUs = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Image = c.String(),
                        Name = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Weight = c.Single(nullable: false),
                        VeterinarianName = c.String(),
                        FoodType = c.String(),
                        Sex = c.String(),
                        RaceId = c.Short(nullable: false),
                        DogSizeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DogSizes", t => t.DogSizeId, cascadeDelete: true)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.RaceId)
                .Index(t => t.DogSizeId);
            
            CreateTable(
                "dbo.DogSizes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Dogs", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Dogs", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Dogs", "DogSizeId", "dbo.DogSizes");
            DropIndex("dbo.Dogs", new[] { "DogSizeId" });
            DropIndex("dbo.Dogs", new[] { "RaceId" });
            DropIndex("dbo.Dogs", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "TrainerId" });
            DropTable("dbo.Races");
            DropTable("dbo.DogSizes");
            DropTable("dbo.Dogs");
            DropTable("dbo.Customers");
        }
    }
}
