namespace StarterKITDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "DOB");
        }
    }
}
