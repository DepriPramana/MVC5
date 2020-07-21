namespace AppWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Drama')");
            Sql("INSERT INTO Genres (Name) VALUES ('Horor')");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO MembershipTypes (Name,signupfee,durationinmonths,discountrate) VALUES ('Pay in Go',10000,2,10)");
            Sql("INSERT INTO MembershipTypes (Name,signupfee,durationinmonths,discountrate) VALUES ('Monthly',10000,5,15)");
            Sql("INSERT INTO MembershipTypes (Name,signupfee,durationinmonths,discountrate) VALUES ('Pay in Go',30000,6,20)");
            Sql("INSERT INTO MembershipTypes (Name,signupfee,durationinmonths,discountrate) VALUES ('Monthly',5000,2,5)");

        }
        
        public override void Down()
        {
        }
    }
}
