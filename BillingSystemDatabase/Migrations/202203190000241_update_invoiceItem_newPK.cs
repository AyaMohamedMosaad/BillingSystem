namespace BillingSystemDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_invoiceItem_newPK : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.IteamInvoices");
            AddColumn("dbo.IteamInvoices", "helper_pk", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.IteamInvoices", "helper_pk");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.IteamInvoices");
            DropColumn("dbo.IteamInvoices", "helper_pk");
            AddPrimaryKey("dbo.IteamInvoices", new[] { "item_id", "invoice_id" });
        }
    }
}
