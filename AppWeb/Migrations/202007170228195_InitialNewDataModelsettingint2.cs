namespace AppWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialNewDataModelsettingint2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            DropColumn("dbo.Movies", "GenreId");
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id", newName: "MembershipTypeId");
            RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "GenreId");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Movies", "GenreId", c => c.Int());
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int());
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembershipType_Id");
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id");
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
