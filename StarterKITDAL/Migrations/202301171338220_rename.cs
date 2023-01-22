namespace StarterKITDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "MemberId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CompanyId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "MemberId");
        }
    }
}
