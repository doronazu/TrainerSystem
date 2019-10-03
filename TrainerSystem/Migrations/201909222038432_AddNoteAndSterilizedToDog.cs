namespace TrainerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoteAndSterilizedToDog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dogs", "Sterilized", c => c.Boolean(nullable: false));
            AddColumn("dbo.Dogs", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dogs", "Note");
            DropColumn("dbo.Dogs", "Sterilized");
        }
    }
}
