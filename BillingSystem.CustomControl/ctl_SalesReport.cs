using System.Windows.Forms;
using BillingSystemDatabase.Model;
using System.Linq;

namespace BillingSystem.CustomControl
{
    public partial class ctl_SalesReport : UserControl
    {
        public ctl_SalesReport()
        {
            InitializeComponent();
        }

        private void btnBrowes_Click(object sender, System.EventArgs e)
        {
            using ( var db = new  BillingSystemDbContext() ) {

                var q = db.Invoices.Select(i => new {
                    bill_number = i.InvoiceNumer,
                    bill_date = i.BillDate,
                    clint_Name = i.Clients.Name,
                    Bill_total = i.BillTotal,
                    Bill_net = i.BillNet,
                    Employee_Name = i.Emp.EmployeeName
                }).ToList().Where(i =>i.bill_date.CompareTo(pToDate.Value)<=0 && i.bill_date.CompareTo(pFromDate.Value)>=0);
                dgInvoice.DataSource = q.ToList();   
            }
        }

        private void dgInvoice_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int BillID = (int)dgInvoice.SelectedRows[0].Cells[0].Value;
            using (var db = new BillingSystemDbContext()) {

                var q = db.InvoiceItems.Where(i => i.invoice_id == BillID).Select(i => new {
                    iteam_Name = i.item.Name,
                    Qunatity = i.Quantity,
                    total_price = i.ItemsTotalPrice,
                }).ToList();
                dgInvoiceItem.DataSource = q.ToList();
            }


        }
    }
}
