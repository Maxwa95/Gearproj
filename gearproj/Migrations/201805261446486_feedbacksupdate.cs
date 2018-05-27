namespace gearproj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedbacksupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FeedBacks", "Userid", "dbo.AspNetUsers");
            DropIndex("dbo.FeedBacks", new[] { "Userid" });
            AlterColumn("dbo.FeedBacks", "Comment", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.FeedBacks", "Userid", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.FeedBacks", "Userid");
            AddForeignKey("dbo.FeedBacks", "Userid", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedBacks", "Userid", "dbo.AspNetUsers");
            DropIndex("dbo.FeedBacks", new[] { "Userid" });
            AlterColumn("dbo.FeedBacks", "Userid", c => c.String(maxLength: 128));
            AlterColumn("dbo.FeedBacks", "Comment", c => c.String(maxLength: 255));
            CreateIndex("dbo.FeedBacks", "Userid");
            AddForeignKey("dbo.FeedBacks", "Userid", "dbo.AspNetUsers", "Id");
        }
    }
}
