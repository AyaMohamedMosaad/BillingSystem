using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BillingSystem.UI.Model;
using BillingSystemDatabase.Model;

namespace BillingSystem.CustomControl
{
    public partial class ctl_Items : UserControl
    {
        private delegate bool validate();

        private BillingSystemDbContext db;
        public ctl_Items()
        {
            InitializeComponent();
            db = new BillingSystemDbContext();
        }



        public void clearAllTexts()
        {
            txtItemName.Text = "";
            txtSellingPrice.Text = "";
            txtBuyingPrice.Text = "";
            txtNotes.Text = "";
        }

        private void item_control_Load(object sender, EventArgs e)
        {
            List<Company> companies = db.Companies.ToList();
            cbCompanyNames.DataSource = companies;
            cbCompanyNames.ValueMember = "Id";
            cbCompanyNames.DisplayMember = "CompanyName";

            List<Unit> units = db.Units.ToList();
            cbUnits.DataSource = units;
            cbUnits.ValueMember = "ID";
            cbUnits.DisplayMember = "Unit_Name";
            cbTypes.Enabled = false;

        }
        private void company_compo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void company_compo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var query = db
                        .GetCompanyCategories.Where(CompanyCategory => CompanyCategory.CompanyId == (int)cbCompanyNames.SelectedValue)
                        .Select(item => new { id = item.Category.Id, name = item.Category.Name })
                        .ToList();
            cbTypes.Enabled = true;
            cbTypes.DataSource = query;
            cbTypes.ValueMember = "id";
            cbTypes.DisplayMember = "name";
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            Item i = new Item();
            i.Name = txtItemName.Text;
            i.sellingPrice = txtSellingPrice.Text == "" ? 0 : Convert.ToDecimal(txtSellingPrice.Text);
            i.BuyingPrice = txtBuyingPrice.Text == "" ? 0 : Convert.ToDecimal(txtBuyingPrice.Text);
            i.Notes = txtNotes.Text;
            if (cbTypes.SelectedValue != null) {
                i.CategoryId = (int)cbTypes.SelectedValue;
            }

            string errorMessages = "";

            //validation
            ValidationContext context = new ValidationContext(i);
            List<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(i, context, errors, true)) {
                foreach (ValidationResult result in errors) {
                    errorMessages += result.ErrorMessage + "\n";
                }
                MessageBox.Show(errorMessages);
            }
            else if (i.BuyingPrice > i.sellingPrice) {
                MessageBox.Show("BUYING PRICE Must be less than or equal SELLING PRICE");
            }
            else if (cbTypes.SelectedValue == null) {
                MessageBox.Show("you must choose category");
            }
            else {
                try {
                    db.Items.Add(i);
                    db.SaveChanges();

                    ItemUnits iu = new ItemUnits();
                    iu.UnitId = (int)cbUnits.SelectedValue;
                    iu.ItemId = i.Id;
                    db.ItemUnitss.Add(iu);
                    db.SaveChanges();
                    clearAllTexts();
                }
                catch {
                    MessageBox.Show("the item name must be unique");
                    db.Items.Remove(i);
                }
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
