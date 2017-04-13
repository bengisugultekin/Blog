namespace Blog_MVC.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteProp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "RememberMe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "RememberMe", c => c.Boolean(nullable: false));
        }
    }
}
