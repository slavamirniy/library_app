namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        BornYear = c.Int(nullable: false),
                        DiedYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        BookName = c.String(),
                        Description = c.String(),
                        Year = c.Int(nullable: false),
                        PagesCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.BookTakes",
                c => new
                    {
                        BookTakeId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        ReaderId = c.Int(nullable: false),
                        TakeDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        Returned = c.Boolean(nullable: false),
                        Accepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookTakeId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        ReaderId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Contact = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ReaderId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.WorkerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Workers");
            DropTable("dbo.Readers");
            DropTable("dbo.Genres");
            DropTable("dbo.BookTakes");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
