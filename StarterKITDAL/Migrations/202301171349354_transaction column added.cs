namespace StarterKITDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactioncolumnadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "MemberCount", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "SpouseCount", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "ChildCount", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "DriverCount", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "OtherCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "OtherCount");
            DropColumn("dbo.Transactions", "DriverCount");
            DropColumn("dbo.Transactions", "ChildCount");
            DropColumn("dbo.Transactions", "SpouseCount");
            DropColumn("dbo.Transactions", "MemberCount");
        }
    }
}
