namespace StarterKITDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class memberchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "FatherName", c => c.String());
            AddColumn("dbo.Members", "Mothername", c => c.String());
            AddColumn("dbo.Members", "BSSYear", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "BSSYear");
            DropColumn("dbo.Members", "Mothername");
            DropColumn("dbo.Members", "FatherName");
        }
    }
}
