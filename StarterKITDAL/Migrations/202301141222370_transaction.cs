namespace StarterKITDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        EventName = c.String(),
                        MemberId = c.String(),
                        Name = c.String(),
                        Mobile = c.String(),
                        Category = c.String(),
                        MemberAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SpouseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChildAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DriverAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BkashTransactionId = c.String(),
                        BkashMobileNo = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        ApprovedBy = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transactions");
        }
    }
}
