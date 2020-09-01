namespace WebShopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProductSizes : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT ProductSizes ON");
            Sql("INSERT INTO ProductSizes (Id, Size) Values (1, 'S')");
            Sql("INSERT INTO ProductSizes (Id, Size) Values (2, 'M')");
            Sql("INSERT INTO ProductSizes (Id, Size) Values (3, 'L')");
            Sql("INSERT INTO ProductSizes (Id, Size) Values (4, '42')");
            Sql("INSERT INTO ProductSizes (Id, Size) Values (5, '43')");
            Sql("INSERT INTO ProductSizes (Id, Size) Values (6, '44')");
        }
        
        public override void Down()
        {
        }
    }
}
