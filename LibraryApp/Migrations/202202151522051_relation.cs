namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "GenreId");
            CreateIndex("dbo.BookTakes", "BookId");
            CreateIndex("dbo.BookTakes", "ReaderId");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
            AddForeignKey("dbo.BookTakes", "BookId", "dbo.Books", "BookId", cascadeDelete: true);
            AddForeignKey("dbo.BookTakes", "ReaderId", "dbo.Readers", "ReaderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookTakes", "ReaderId", "dbo.Readers");
            DropForeignKey("dbo.BookTakes", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.BookTakes", new[] { "ReaderId" });
            DropIndex("dbo.BookTakes", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropColumn("dbo.Books", "GenreId");
        }
    }
}
