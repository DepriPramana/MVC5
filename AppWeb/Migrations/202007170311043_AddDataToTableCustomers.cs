namespace AppWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToTableCustomers : DbMigration
    {
        public override void Up()
        {

            Sql("insert into customers (name,issubscribedtonewsletter,membershiptypeid,birthdate) values ('Depri Pramana',0,1,'12/08/1988')");
            Sql("insert into customers (name,issubscribedtonewsletter,membershiptypeid,birthdate) values ('Arvino',0,2,'12/08/1988')");
            Sql("insert into customers (name,issubscribedtonewsletter,membershiptypeid,birthdate) values ('Michio',0,2,'12/08/1988')");
            Sql("insert into customers (name,issubscribedtonewsletter,membershiptypeid,birthdate) values ('Devrina',0,3,'12/08/1988')");
        }
        
        public override void Down()
        {
        }
    }
}
