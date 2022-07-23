using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BillingSystem.UI.Model
{
    public class Employee
    {
        [Key]
        public int EmpolyeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is Required")]
        public string EmployeeName { get; set; }


        //navegator
        public virtual List<Invoice> Invoices { get; set; }
    }
}
