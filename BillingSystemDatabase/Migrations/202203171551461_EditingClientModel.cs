namespace BillingSystemDatabase.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EditingClientModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Clients", "Name", unique: true);
        }

        public override void Down()
        {
            DropIndex("dbo.Clients", new[] { "Name" });
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false));
        }
    }
}
