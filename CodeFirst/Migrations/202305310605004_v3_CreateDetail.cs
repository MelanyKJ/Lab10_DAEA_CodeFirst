namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3_CreateDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        DetailID = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetailID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.InvoiceID);
            
            AddColumn("dbo.Products", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Details", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Details", new[] { "InvoiceID" });
            DropIndex("dbo.Details", new[] { "ProductID" });
            DropColumn("dbo.Products", "Price");
            DropTable("dbo.Details");
        }
    }
}
