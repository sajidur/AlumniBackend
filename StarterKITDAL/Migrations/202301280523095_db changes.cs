namespace StarterKITDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "MemberNo", c => c.String());
            AddColumn("dbo.Transactions", "EventPlace", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "EventPlace");
            DropColumn("dbo.Members", "MemberNo");
        }
    }
}
