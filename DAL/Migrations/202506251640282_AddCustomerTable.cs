namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Loans", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Loans", "Customer_Id");
            AddForeignKey("dbo.Loans", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Loans", new[] { "Customer_Id" });
            DropColumn("dbo.Loans", "Customer_Id");
            DropTable("dbo.Customers");
        }
    }
}
