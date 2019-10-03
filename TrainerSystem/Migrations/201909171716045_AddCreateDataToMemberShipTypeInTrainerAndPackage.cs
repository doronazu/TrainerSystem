namespace TrainerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateDataToMemberShipTypeInTrainerAndPackage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Packages", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trainers", "MembershipTypeCreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "MembershipTypeCreateDate");
            DropColumn("dbo.Packages", "CreateDate");
        }
    }
}
