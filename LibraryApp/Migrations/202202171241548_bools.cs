namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bools : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookTakes", "Returned", c => c.Boolean());
            AlterColumn("dbo.BookTakes", "Accepted", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookTakes", "Accepted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.BookTakes", "Returned", c => c.Boolean(nullable: false));
        }
    }
}
