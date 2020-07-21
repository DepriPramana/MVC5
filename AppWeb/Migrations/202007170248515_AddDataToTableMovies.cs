namespace AppWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToTableMovies : DbMigration
    {
        public override void Up()
        {
            Sql("insert into movies (name,genreid,releasedate,dateadded,instock) values ('Jurasik Park',1,'11/01/2005','07/17/2010',10)");
            Sql("insert into movies (name,genreid,releasedate,dateadded,instock) values ('Pokemon',2,'11/01/2003','07/17/2010',10)");
            Sql("insert into movies (name,genreid,releasedate,dateadded,instock) values ('Scoby do bi do',3,'11/01/2002','07/17/2010',10)");
            Sql("insert into movies (name,genreid,releasedate,dateadded,instock) values ('Spongebob',2,'11/01/2004','07/17/2010',10)");
        }
        
        public override void Down()
        {
        }
    }
}
