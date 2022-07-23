using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Windows.Forms;
using BillingSystem.UI.Model;
using BillingSystemDatabase.Model;

namespace BillingSystem.CustomControl
{
    public partial class ctl_Units : UserControl
    {
        //BillingSystemDbContext db;
        public ctl_Units()
        {
            InitializeComponent();
            //db = new BillingSystemDbContext();
            ;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            errorProvider.SetError(txt_unit_name, "");
            Unit unit = new Unit() {
                Unit_Name = txt_unit_name.Text,
                Notes = txt_unit_notes.Text,
            };

            ValidationContext context = new ValidationContext(unit);
            List<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(unit, context, errors, true)) {
                foreach (ValidationResult result in errors) {
                    //MessageBox.Show(result.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorProvider.SetError(txt_unit_name, result.ErrorMessage);
                }
            }
            else {
                try {
                    DialogResult result = MessageBox.Show($"Are you want to insert {txt_unit_name.Text} Unit", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK) {
                        using (BillingSystemDbContext db = new BillingSystemDbContext()) {
                            db.Units.Add(unit);
                            db.SaveChanges();
                            MessageBox.Show($"Unit {txt_unit_name.Text} added Successfuly", "Success", MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
                            ClearFields();
                        }
                    }
                }
                catch (DbUpdateException) {
                    MessageBox.Show("This Unit is Already Exists", "Duplicate", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                }
            }


        }

        private void ClearFields() => txt_unit_name.Text = txt_unit_notes.Text = string.Empty;

        private void btnCancel_Click(object sender, EventArgs e) => ClearFields();

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
