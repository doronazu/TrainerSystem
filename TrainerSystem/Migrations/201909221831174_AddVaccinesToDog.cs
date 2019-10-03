namespace TrainerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVaccinesToDog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vaccines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DogId = c.Int(nullable: false),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dogs", t => t.DogId, cascadeDelete: true)
                .Index(t => t.DogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vaccines", "DogId", "dbo.Dogs");
            DropIndex("dbo.Vaccines", new[] { "DogId" });
            DropTable("dbo.Vaccines");
        }
    }
}
