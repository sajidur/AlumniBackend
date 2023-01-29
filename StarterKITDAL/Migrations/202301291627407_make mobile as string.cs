namespace StarterKITDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makemobileasstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Mobile", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Mobile", c => c.Long(nullable: false));
        }
    }
}
