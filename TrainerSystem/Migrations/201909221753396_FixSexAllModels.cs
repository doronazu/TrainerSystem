namespace TrainerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixSexAllModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Sex", c => c.Int(nullable: false));
            AlterColumn("dbo.Dogs", "Sex", c => c.Int(nullable: false));
            AlterColumn("dbo.Trainers", "Sex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "Sex", c => c.String());
            AlterColumn("dbo.Dogs", "Sex", c => c.String());
            DropColumn("dbo.Customers", "Sex");
        }
    }
}
