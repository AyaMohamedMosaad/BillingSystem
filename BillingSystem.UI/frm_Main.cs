using System.Drawing;
using System.Windows.Forms;
using BillingSystem.CustomControl;

namespace BillingSystem.UI
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height);
            picAvatar.Region = new Region(path);
        }

        private void AddControl(UserControl control, int x, int y)
        {
            pnlContainer.Controls.Clear();
            control.Location = new Point(x, y);
            pnlContainer.Controls.Add(control);
        }

        private void btnHomePage_Click(object sender, System.EventArgs e)
        {

        }

        private void btnCompanyData_Click(object sender, System.EventArgs e)
        {
            ctl_CompanyData companyData = new ctl_CompanyData();
            AddControl(companyData, 150, 100);
        }

        private void btnSpeciesData_Click(object sender, System.EventArgs e)
        {
            ctl_TypesForm typesForm = new ctl_TypesForm();
            AddControl(typesForm, 150, 100);
        }

        private void btnUnits_Click(object sender, System.EventArgs e)
        {
            ctl_Units units = new ctl_Units();
            AddControl(units, 150, 100);
        }

        private void btnClients_Click(object sender, System.EventArgs e)
        {
            ctl_Clients clients = new ctl_Clients();
            AddControl(clients, 150, 100);
        }

        private void btnSalesReports_Click(object sender, System.EventArgs e)
        {
            ctl_SalesReport salesReport = new ctl_SalesReport();
            AddControl(salesReport, 150, 100);
        }

        private void btnCategories_Click(object sender, System.EventArgs e)
        {
            ctl_Items item = new ctl_Items();
            AddControl(item, 150, 20);
        }

        private void btnSalesInvoice_Click(object sender, System.EventArgs e)
        {
            ctl_Invoice invoice = new ctl_Invoice();
            AddControl(invoice, 150, 50);
        }
    }
}
