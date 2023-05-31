namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2_CreateInvoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        CustomerID = c.String(),
                        Customer_CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.Invoices", new[] { "Customer_CustomerID" });
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
        }
    }
}
