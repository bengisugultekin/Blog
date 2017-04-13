namespace Blog_MVC.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PictureUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PictureUrl");
        }
    }
}
