namespace gearproj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ModelId", "dbo.Models");
            DropIndex("dbo.Products", new[] { "ModelId" });
            CreateTable(
                "dbo.modelsproducts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        modelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Models", t => t.modelId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId)
                .Index(t => t.modelId);
            
            DropColumn("dbo.Products", "ModelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ModelId", c => c.Int(nullable: false));
            DropForeignKey("dbo.modelsproducts", "productId", "dbo.Products");
            DropForeignKey("dbo.modelsproducts", "modelId", "dbo.Models");
            DropIndex("dbo.modelsproducts", new[] { "modelId" });
            DropIndex("dbo.modelsproducts", new[] { "productId" });
            DropTable("dbo.modelsproducts");
            CreateIndex("dbo.Products", "ModelId");
            AddForeignKey("dbo.Products", "ModelId", "dbo.Models", "ModelId", cascadeDelete: true);
        }
    }
}
