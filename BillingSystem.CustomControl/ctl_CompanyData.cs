using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using BillingSystem.UI.Model;
using BillingSystemDatabase.Model;

namespace BillingSystem.CustomControl
{
    public partial class ctl_CompanyData : UserControl
    {
        Dictionary<string, TextBox> controllMaper = new Dictionary<string, TextBox>();

        private BillingSystemDbContext _billingSystemDb;

        public ctl_CompanyData()
        {
            InitializeComponent();
            _billingSystemDb = new BillingSystemDbContext();
            controllMaper.Add("Company Name is Required", txtCompanyName);
         

        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {

            //clear error 
            errorProvider.Clear();

            Company company = new Company();
            company.CompanyName = txtCompanyName.Text;
            company.Notes = txtCompanyNotes.Text;


            //input validation
            ValidationContext context = new ValidationContext(company);
            List<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(company, context, errors, true))
            {
                foreach (ValidationResult error in errors)
                {
                    errorProvider.SetError(controllMaper[error.ErrorMessage], error.ErrorMessage);
                }
            }
            else
            {
                using (var db = new BillingSystemDbContext())
                {
                    try
                    {
                        db.Companies.Add(company);
                        db.SaveChanges();
                        //confirm added
                        MessageBox.Show("added");
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("COMPANY NAME has already existed before");
                        db.Companies.Remove(company);
                        ClearFields();
                    }
                }

            }


        }

        private void ClearFields()=> txtCompanyName.Text= txtCompanyNotes.Text= String.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();

        }
    }
}
