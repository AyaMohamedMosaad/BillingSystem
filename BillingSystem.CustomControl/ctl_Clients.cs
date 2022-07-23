using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using BillingSystem.UI.Model;
using BillingSystemDatabase.Model;
namespace BillingSystem.CustomControl
{
    public partial class ctl_Clients : UserControl
    {
        private BillingSystemDbContext BS;
        private Dictionary<string, TextBox> ControllMaper;
        public ctl_Clients()
        {
            BS = new BillingSystemDbContext();
            ControllMaper = new Dictionary<string, TextBox>();
            InitializeComponent();
            ControllMaper.Add("Client Name is Required", txt_clientName);
            ControllMaper.Add("Name Must be between 3 to 50 character", txt_clientName);
            ControllMaper.Add("Client Phone is Required", txt_clientPhone);
            ControllMaper.Add("Phone Must be 14 digit", txt_clientPhone);
            ControllMaper.Add("Phone Number is Not Valid", txt_clientPhone);
            ControllMaper.Add("Address is Required", txt_clientAddress);



        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {



            Client clint = BS.Clients.ToList().LastOrDefault();



            if (clint != null) {
                txt_clientNumber.Text = (clint.Number + 1).ToString();
                txt_clientNumber.Enabled = false;
            }
            else {



                txt_clientNumber.Text = "1";
                txt_clientNumber.Enabled = false;
            }




        }



        private void btnSave_Click(object sender, System.EventArgs e)
        {



            errorProvName.SetError(txt_clientName, "");
            errorProvName.SetError(txt_clientPhone, "");
            errorProvName.SetError(txt_clientAddress, "");



            Client client = new Client() {
                Name = txt_clientName.Text,
                Address = txt_clientAddress.Text,
                Phone = txt_clientPhone.Text,



            };



            ValidationContext context = new ValidationContext(client);
            List<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(client, context, errors, true)) {
                foreach (ValidationResult er in errors) {
                    errorProvName.SetError(ControllMaper[er.ErrorMessage], er.ErrorMessage);
                }
            }
            else {
                try {


                    DialogResult result = MessageBox.Show($"Are you want to insert {txt_clientName.Text} As a client", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);



                    if (result == DialogResult.OK) {



                        using (BillingSystemDbContext db = new BillingSystemDbContext()) {
                            db.Clients.Add(client);
                            db.SaveChanges();
                            txt_clientName.Text = txt_clientAddress.Text = txt_clientNumber.Text = txt_clientPhone.Text = "";
                            txt_clientNumber.Text = (client.Number + 1).ToString();
                            MessageBox.Show($"Client Name {txt_clientName.Text}is added Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (DbUpdateException) {
                    MessageBox.Show("Client Name is Already Exists", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void label7_Click(object sender, System.EventArgs e)
        {



        }
    }
}