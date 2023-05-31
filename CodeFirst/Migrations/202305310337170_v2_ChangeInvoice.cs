namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2_ChangeInvoice : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.Invoices", new[] { "Customer_CustomerID" });
            DropColumn("dbo.Invoices", "CustomerID");
            RenameColumn(table: "dbo.Invoices", name: "Customer_CustomerID", newName: "CustomerID");
            AlterColumn("dbo.Invoices", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "CustomerID");
            AddForeignKey("dbo.Invoices", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Invoices", new[] { "CustomerID" });
            AlterColumn("dbo.Invoices", "CustomerID", c => c.Int());
            AlterColumn("dbo.Invoices", "CustomerID", c => c.String());
            RenameColumn(table: "dbo.Invoices", name: "CustomerID", newName: "Customer_CustomerID");
            AddColumn("dbo.Invoices", "CustomerID", c => c.String());
            CreateIndex("dbo.Invoices", "Customer_CustomerID");
            AddForeignKey("dbo.Invoices", "Customer_CustomerID", "dbo.Customers", "CustomerID");
        }
    }
}
