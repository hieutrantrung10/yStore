namespace yStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePostData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ViewCount", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "MetaKeyword", c => c.String(maxLength: 256));
            AddColumn("dbo.Posts", "MetaDescription", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "MetaDescription");
            DropColumn("dbo.Posts", "MetaKeyword");
            DropColumn("dbo.Posts", "ViewCount");
        }
    }
}
