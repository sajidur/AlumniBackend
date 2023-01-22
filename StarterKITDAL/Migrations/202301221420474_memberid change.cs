namespace StarterKITDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class memberidchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "MemberId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "MemberId", c => c.String());
        }
    }
}
