namespace AppWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialNewDataModelsettingint3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropPrimaryKey("dbo.MembershipTypes");
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            AddPrimaryKey("dbo.Genres", "Id");
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
            DropPrimaryKey("dbo.Genres");
            DropPrimaryKey("dbo.MembershipTypes");
            AlterColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.MembershipTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            CreateIndex("dbo.Movies", "GenreId");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
