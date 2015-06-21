namespace TheWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.project", "NameProject", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.project", "NameProject", c => c.Int(nullable: false));
        }
    }
}
