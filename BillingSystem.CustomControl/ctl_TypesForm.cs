using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using BillingSystem.UI.Model;
using BillingSystemDatabase.Model;
namespace BillingSystem.CustomControl
{
    public partial class ctl_TypesForm : UserControl
    {
        private BillingSystemDbContext db;
        public ctl_TypesForm()
        {
            InitializeComponent();
            db = new BillingSystemDbContext();

        }

        private void label5_Click(object sender, System.EventArgs e)
        {

        }


        private void loadCompanyName()
        {


        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            Category cat = new Category() {
                Name = type_txt.Text,
                Notes = notes_txt.Text
            };

            ValidationContext context = new ValidationContext(cat);
            List<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(cat, context, errors, true)) {
                foreach (ValidationResult result in errors) {
                    MessageBox.Show(result.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else {
                //add new category
                try {
                    db.Categories.Add(cat);
                    db.SaveChanges();

                    //insert into relation table
                    int cat_id = cat.Id;
                    CompanyCategory comp_cat = new CompanyCategory() {
                        CategoryId = cat_id,
                        CompanyId = (int)company_compo.SelectedValue
                    };
                    db.GetCompanyCategories.Add(comp_cat);
                    db.SaveChanges();

                    type_txt.Text = notes_txt.Text = "";
                }
                catch (Exception) {
                    MessageBox.Show("This Unit is Already Exists");
                    db.Categories.Remove(cat);
                }
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            company_compo.DataSource = db.Companies.ToList();
            company_compo.ValueMember = "CompanyName";
            company_compo.ValueMember = "Id";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
