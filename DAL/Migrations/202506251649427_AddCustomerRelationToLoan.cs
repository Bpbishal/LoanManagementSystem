namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerRelationToLoan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Loans", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Loans", new[] { "Customer_Id" });
            RenameColumn(table: "dbo.Loans", name: "Customer_Id", newName: "CustomerId");
            AlterColumn("dbo.Loans", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Loans", "CustomerId");
            AddForeignKey("dbo.Loans", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Loans", new[] { "CustomerId" });
            AlterColumn("dbo.Loans", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.Loans", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Loans", "Customer_Id");
            AddForeignKey("dbo.Loans", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
