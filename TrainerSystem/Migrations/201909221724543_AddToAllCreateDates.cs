namespace TrainerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToAllCreateDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dogs", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DogSizes", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Races", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Races", "CreateDate");
            DropColumn("dbo.DogSizes", "CreateDate");
            DropColumn("dbo.Dogs", "CreateDate");
        }
    }
}
