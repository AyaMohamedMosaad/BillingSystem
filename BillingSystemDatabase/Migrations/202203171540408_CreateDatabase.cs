namespace BillingSystemDatabase.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Notes = c.String(maxLength: 250),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);

            CreateTable(
                "dbo.CompanyCategories",
                c => new {
                    CompanyId = c.Int(nullable: false),
                    CategoryId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.CompanyId, t.CategoryId })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.Companies",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    CompanyName = c.String(nullable: false, maxLength: 50),
                    Notes = c.String(maxLength: 250),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CompanyName, unique: true);

            CreateTable(
                "dbo.Items",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    BuyingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    sellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Notes = c.String(maxLength: 250),
                    CategoryId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.IteamInvoices",
                c => new {
                    item_id = c.Int(nullable: false),
                    invoice_id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.item_id, t.invoice_id })
                .ForeignKey("dbo.Invoices", t => t.invoice_id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.item_id, cascadeDelete: true)
                .Index(t => t.item_id)
                .Index(t => t.invoice_id);

            CreateTable(
                "dbo.Invoices",
                c => new {
                    InvoiceNumer = c.Int(nullable: false, identity: true),
                    BillDate = c.DateTime(nullable: false),
                    DiscountPercentage = c.Int(nullable: false),
                    BillTotal = c.Double(nullable: false),
                    BillNet = c.Double(nullable: false),
                    PaidUp = c.Double(nullable: false),
                    EmployeeId = c.Int(nullable: false),
                    ClientId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.InvoiceNumer)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ClientId);

            CreateTable(
                "dbo.Clients",
                c => new {
                    Number = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Phone = c.String(nullable: false, maxLength: 14),
                    Address = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Number);

            CreateTable(
                "dbo.Employees",
                c => new {
                    EmpolyeeId = c.Int(nullable: false, identity: true),
                    EmployeeName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.EmpolyeeId);

            CreateTable(
                "dbo.ItemUnits",
                c => new {
                    ItemId = c.Int(nullable: false),
                    UnitId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.ItemId, t.UnitId })
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.UnitId);

            CreateTable(
                "dbo.Units",
                c => new {
                    ID = c.Int(nullable: false, identity: true),
                    Unit_Name = c.String(nullable: false, maxLength: 20),
                    Notes = c.String(maxLength: 250),
                })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Unit_Name, unique: true);

        }

        public override void Down()
        {
            DropForeignKey("dbo.ItemUnits", "UnitId", "dbo.Units");
            DropForeignKey("dbo.ItemUnits", "ItemId", "dbo.Items");
            DropForeignKey("dbo.IteamInvoices", "item_id", "dbo.Items");
            DropForeignKey("dbo.IteamInvoices", "invoice_id", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Invoices", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CompanyCategories", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CompanyCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Units", new[] { "Unit_Name" });
            DropIndex("dbo.ItemUnits", new[] { "UnitId" });
            DropIndex("dbo.ItemUnits", new[] { "ItemId" });
            DropIndex("dbo.Invoices", new[] { "ClientId" });
            DropIndex("dbo.Invoices", new[] { "EmployeeId" });
            DropIndex("dbo.IteamInvoices", new[] { "invoice_id" });
            DropIndex("dbo.IteamInvoices", new[] { "item_id" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "Name" });
            DropIndex("dbo.Companies", new[] { "CompanyName" });
            DropIndex("dbo.CompanyCategories", new[] { "CategoryId" });
            DropIndex("dbo.CompanyCategories", new[] { "CompanyId" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropTable("dbo.Units");
            DropTable("dbo.ItemUnits");
            DropTable("dbo.Employees");
            DropTable("dbo.Clients");
            DropTable("dbo.Invoices");
            DropTable("dbo.IteamInvoices");
            DropTable("dbo.Items");
            DropTable("dbo.Companies");
            DropTable("dbo.CompanyCategories");
            DropTable("dbo.Categories");
        }
    }
}
