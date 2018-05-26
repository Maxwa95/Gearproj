namespace gearproj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShippingCompanies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ShippingCompanies", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShippingCompanies", "Address", c => c.Single(nullable: false));
            AlterColumn("dbo.ShippingCompanies", "Name", c => c.Int(nullable: false));
        }
    }
}
