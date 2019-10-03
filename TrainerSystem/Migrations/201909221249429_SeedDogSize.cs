namespace TrainerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDogSize : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[DogSizes] ([Id], [Name]) VALUES (1, N'קטן')
INSERT INTO [dbo].[DogSizes] ([Id], [Name]) VALUES (2, N'בינוני')
INSERT INTO [dbo].[DogSizes] ([Id], [Name]) VALUES (3, N'גדול')

");
        }
        
        public override void Down()
        {
        }
    }
}
