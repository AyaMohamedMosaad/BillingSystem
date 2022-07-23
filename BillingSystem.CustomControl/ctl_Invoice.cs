using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BillingSystem.CustomControl.Properties;
using BillingSystem.UI.Model;
using BillingSystemDatabase.Model;

namespace BillingSystem.CustomControl
{
    public partial class ctl_Invoice : UserControl
    {
        Invoice invoice;
        private BillingSystemDbContext dbContext;
        private DataTable _dataTable;
        private decimal billTotal;
        public ctl_Invoice()
        {
            InitializeComponent();
            dbContext = new BillingSystemDbContext();
            SetBillNumber();
            cbDiscountType.SelectedIndex = 0;
            _dataTable = CreateTable();
            LoadClientsName();
            LoadItems();
            dgvItems.DataSource = _dataTable;
            CreateDataGridViewColumn();
            LoadEmployees();
        }

        private void LoadClientsName()
        {
            cbClientNames.ValueMember = "Number";
            cbClientNames.DisplayMember = "Name";
            var clients = dbContext.Clients.Select(c => new { c.Number, c.Name }).ToList();
            clients.Insert(0, new { Number = 0, Name = "Please Select Client..." });
            cbClientNames.DataSource = clients;
        }

        private void LoadItems()
        {
            cbItems.ValueMember = "Id";
            cbItems.DisplayMember = "Name";
            var items = dbContext.Items.Select(i => new { i.Id, i.Name }).ToList();
            items.Insert(0, new { Id = 0, Name = "Please Select Item..." });
            cbItems.DataSource = items;
        }

        private void LoadEmployees()
        {
            cbEmployees.ValueMember = "EmpolyeeId";
            cbEmployees.DisplayMember = "EmployeeName";
            var employees = dbContext.Employees.Select(e => new { e.EmpolyeeId, e.EmployeeName }).ToList();
            employees.Insert(0, new { EmpolyeeId = 0, EmployeeName = "Please Select Employee..." });
            cbEmployees.DataSource = employees;
        }

        private void SetBillNumber() => udBillsNumber.Value = dbContext.Invoices.ToList().LastOrDefault() == null ? 1 : dbContext.Invoices.ToList().LastOrDefault().InvoiceNumer + 1;

        private void cbDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            udDiscount.Value = udDiscount.Minimum;
            switch (cbDiscountType.SelectedIndex) {
                case 1:
                    lblDiscount.Text = "PERCENTAGE DISCOUNT :";
                    udDiscount.Visible = lblDiscount.Visible = true;
                    udDiscount.Minimum = 0;
                    udDiscount.Maximum = 80;
                    udDiscount.DecimalPlaces = 0;
                    break;
                case 2:
                    lblDiscount.Text = "VALUE DISCOUNT :";
                    udDiscount.Visible = lblDiscount.Visible = true;
                    udDiscount.Minimum = 0;
                    udDiscount.Maximum = 100000;
                    udDiscount.DecimalPlaces = 2;
                    break;
                default:
                    udDiscount.Visible = lblDiscount.Visible = false;
                    udBillsNet.Value = udBillsTotal.Value;
                    break;
            }
        }

        private void cbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbItems.SelectedIndex != 0) {
                int itemId = (int)cbItems.SelectedValue;
                Item item = dbContext.Items.SingleOrDefault(i => i.Id == itemId);
                udSellingPrice.Value = item.sellingPrice;
                udItemsTotalPrice.Value = (int)udQuntity.Value * (int)udSellingPrice.Value;
            }
            else {
                udSellingPrice.Value = udSellingPrice.Minimum;
                udQuntity.Value = udQuntity.Minimum;
                udItemsTotalPrice.Value = udItemsTotalPrice.Minimum;
            }
        }

        private void udQuntity_ValueChanged(object sender, EventArgs e) => udItemsTotalPrice.Value = (int)udQuntity.Value * (int)udSellingPrice.Value;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbItems.SelectedIndex != 0) {

                // Create Row
                DataRow row = _dataTable.NewRow();
                int itemId = (int)cbItems.SelectedValue;
                int unitId = dbContext.ItemUnitss.Where(iu => iu.ItemId == itemId).Select(i => i.UnitId).SingleOrDefault();

                //if (_dataTable.Rows.Count != 0) {
                //    row["Item Code"] = cbItems.SelectedValue;
                //    row["Item Name"] = cbItems.Text;
                //    row["Unit"] = dbContext.Units.Where(u => u.ID == unitId).Select(u => u.Unit_Name).SingleOrDefault();
                //    row["Quantity"] = row["Total"] = udItemsTotalPrice.Value; ;
                //    row["Selling Price"] = udSellingPrice.Value;
                //    row["Total"] = udItemsTotalPrice.Value;

                //    add Data to DataTable
                //    _dataTable.Rows.Add(row);
                //    MessageBox.Show("add");
                //}
                //else {
                //    foreach (DataRow dr in _dataTable.Rows) {

                //        MessageBox.Show("hereee");
                //        if ((int)dr["Item Code"] == itemId) {
                //            update the quan
                //            int oldQuantaty = (int)row["Quantity"];
                //            row["Quantity"] = oldQuantaty + (int)udItemsTotalPrice.Value;
                //            MessageBox.Show("hehre");
                //            update total
                //            decimal oldTotal = (decimal)row["Total"];
                //            row["Total"] = oldTotal + udItemsTotalPrice.Value;
                //        }
                //        else {
                //            Add Data to row
                //            row["Item Code"] = cbItems.SelectedValue;
                //            row["Item Name"] = cbItems.Text;
                //            row["Unit"] = dbContext.Units.Where(u => u.ID == unitId).Select(u => u.Unit_Name).SingleOrDefault();
                //            row["Quantity"] = row["Total"] = udItemsTotalPrice.Value; ;
                //            row["Selling Price"] = udSellingPrice.Value;
                //            row["Total"] = udItemsTotalPrice.Value;

                //            add Data to DataTable
                //            _dataTable.Rows.Add(row);
                //            MessageBox.Show("add");
                //        }

                //    }
                //}


                row["Item Code"] = cbItems.SelectedValue;
                row["Item Name"] = cbItems.Text;
                row["Unit"] = dbContext.Units.Where(u => u.ID == unitId).Select(u => u.Unit_Name).SingleOrDefault();
                row["Quantity"] = row["Total"] = udItemsTotalPrice.Value; ;
                row["Selling Price"] = udSellingPrice.Value;
                row["Total"] = udItemsTotalPrice.Value;

                //add Data to DataTable
                            _dataTable.Rows.Add(row);


                // update DataGridView DataSource
                dgvItems.DataSource = _dataTable;

                // add to Bill Total
                billTotal += (decimal)udItemsTotalPrice.Value;
                udBillsTotal.Value = billTotal;

                if (cbDiscountType.SelectedIndex == 0) {
                    udBillsNet.Value = udBillsTotal.Value;
                }

                // Reset Fields
                ResetItemDetailsFields();
            }
            else {
                MessageBox.Show("Please Select Item To add it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private DataTable CreateTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Item Code", typeof(int));
            dataTable.Columns.Add("Item Name", typeof(string));
            dataTable.Columns.Add("Unit", typeof(string));
            dataTable.Columns.Add("Quantity", typeof(int));
            dataTable.Columns.Add("Selling Price", typeof(decimal));
            dataTable.Columns.Add("Total", typeof(decimal));
            return dataTable;
        }

        private void ResetItemDetailsFields()
        {
            cbItems.SelectedIndex = 0;
            udSellingPrice.Value = udSellingPrice.Minimum;
            udItemsTotalPrice.Value = udItemsTotalPrice.Minimum;
            udQuntity.Value = udQuntity.Minimum;
        }

        private void udDiscount_ValueChanged(object sender, EventArgs e)
        {
            switch (cbDiscountType.SelectedIndex) {
                case 1:
                    // Percentage Discount
                    udBillsNet.Value = (billTotal - ((udDiscount.Value / 100) * billTotal));
                    break;
                case 2:
                    // Value Discount
                    udBillsNet.Value = billTotal - udDiscount.Value;
                    break;
                default:
                    // Not Selected
                    udBillsNet.Value = udBillsTotal.Value;
                    break;
            }
        }

        private void CreateDataGridViewColumn()
        {
            DataGridViewImageColumn dataGridViewColumn = new DataGridViewImageColumn();
            dataGridViewColumn.Width = 30;
            dataGridViewColumn.Image = Resources.trash;
            dgvItems.Columns.Add(dataGridViewColumn);
        }

        private void btnSaveBill_Click(object sender, EventArgs e)
        {
             invoice = new Invoice();
            invoice.BillDate = dtBillsDate.Value.Date;
            switch (cbDiscountType.SelectedIndex) {
                case 1:
                    invoice.DiscountPercentage = (int)udDiscount.Value;
                    break;
                case 2:
                    invoice.DiscountPercentage = (int)((udDiscount.Value / billTotal) * 100);
                    break;
                default:
                    invoice.DiscountPercentage = 0;
                    break;
            }
            invoice.BillTotal = (double)udBillsTotal.Value;
            invoice.BillNet = (double)udBillsNet.Value;
            invoice.PaidUp = (double)udPaidUp.Value;
            invoice.BillRest = (invoice.BillNet - invoice.PaidUp);

            if (cbClientNames.SelectedIndex != 0) {
                invoice.ClientId = (int)cbClientNames.SelectedValue;
            }
            else {
                MessageBox.Show("Please Select Client Name", "Request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbEmployees.SelectedIndex != 0) {
                invoice.EmployeeId = (int)cbEmployees.SelectedValue;
            }
            else {
                MessageBox.Show("Please Select Employee Name", "Request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ValidationContext context = new ValidationContext(invoice);
            List<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(invoice, context, errors, true)) {
                foreach (ValidationResult error in errors) {
                    MessageBox.Show(error.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }
            else {
                if (_dataTable.Rows.Count == 0) {
                    MessageBox.Show("Can not Create a Bill With Zero Item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else {
            
                        dbContext.Invoices.Add(invoice);
                        dbContext.SaveChanges();
                        SaveBillItems(_dataTable);
                        SetBillNumber();
                        ResetBillFields();
                        MessageBox.Show("Invoice Saved Successfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }


        }

        private void SaveBillItems(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++) {
                IteamInvoice invoiceIteams = new IteamInvoice() {
                    item_id = (int)dataTable.Rows[i].Field<int>(0),

                    //fix
                    //  invoice_id = (int)udBillsNumber.Value,
                    invoice_id = invoice.InvoiceNumer,
                    Quantity = (int)dataTable.Rows[i].Field<int>(3),
                    ItemsTotalPrice = (int)dataTable.Rows[i].Field<decimal>(5),
                };
                dbContext.InvoiceItems.Add(invoiceIteams);
                dbContext.SaveChanges();
            }
        }

        private void ResetBillFields()
        {
            _dataTable.Clear();
            dgvItems.DataSource = _dataTable;
            cbClientNames.SelectedIndex = cbEmployees.SelectedIndex = cbDiscountType.SelectedIndex = 0;
            udBillsTotal.Value = udBillsTotal.Minimum;
            udBillsNet.Value = udBillsNet.Minimum;
            udPaidUp.Value = udPaidUp.Minimum;

        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.ColumnIndex == 0) {
                DialogResult choice = MessageBox.Show($"Are you want to delete this item", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (choice == DialogResult.OK) {

                    // update Bill Total and Bill Net
                    billTotal -= (decimal)dgvItems.CurrentRow.Cells["Total"].Value;
                    udBillsTotal.Value = billTotal;

                    if (cbDiscountType.SelectedIndex == 0) {
                        udBillsNet.Value = udBillsTotal.Value;
                    }

                    _dataTable.Rows.RemoveAt(dgvItems.CurrentRow.Index);
                    dgvItems.DataSource = _dataTable;

                    MessageBox.Show("Item Deleted Successfuly", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
