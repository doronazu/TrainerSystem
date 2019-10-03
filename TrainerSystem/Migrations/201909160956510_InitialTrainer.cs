namespace TrainerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTrainer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        Visible = c.Boolean(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ProfileImage = c.String(),
                        SubjectImage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                        Name = c.String(),
                        Sex = c.String(),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId)
                .Index(t => t.ShopId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.Trainers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Trainers", new[] { "ShopId" });
            DropIndex("dbo.Trainers", new[] { "MembershipTypeId" });
            DropTable("dbo.Trainers");
            DropTable("dbo.Shops");
            DropTable("dbo.MembershipTypes");
        }
    }
}
