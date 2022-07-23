namespace BillingSystemDatabase.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddingQuantityandtotalforInvoiceItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IteamInvoices", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.IteamInvoices", "ItemsTotalPrice", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.IteamInvoices", "ItemsTotalPrice");
            DropColumn("dbo.IteamInvoices", "Quantity");
        }
    }
}
