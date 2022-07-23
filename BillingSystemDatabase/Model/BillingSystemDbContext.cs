using System.Data.Entity;
using BillingSystem.UI.Model;

namespace BillingSystemDatabase.Model
{
    public class BillingSystemDbContext : DbContext
    {
        public BillingSystemDbContext()
            : base("name=BillingSystemDbContext")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CompanyCategory> GetCompanyCategories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<ItemUnits> ItemUnitss { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<IteamInvoice> InvoiceItems { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}