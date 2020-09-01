namespace WebShopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Web.Mvc.Ajax;

    public partial class PopulateProductTypes : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT ProductTypes ON");
            Sql("INSERT INTO ProductTypes (Id, Type) Values (1, 'TShirt')");
            Sql("INSERT INTO ProductTypes (Id, Type) Values (2, 'Hoodie')");
            Sql("INSERT INTO ProductTypes (Id, Type) Values (3, 'Sneaker')");
        }
        
        public override void Down()
        {
        }
    }
}
