namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Exist", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Exist");
        }
    }
}
