using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BillingSystem.UI.Model
{
    public class Invoice
    {
        [Key]
        public int InvoiceNumer { get; set; }

        [Required(ErrorMessage = "Bill Date is Required")]
        [Column(TypeName = "datetime")]
        [DataType(DataType.Date, ErrorMessage = "Invaild Date input")]
        public DateTime BillDate { get; set; }

        [Range(0, 70, ErrorMessage = "Discount Must be between 0% to 70%")]
        public int DiscountPercentage { get; set; }

        public double BillTotal { get; set; }

        public double BillNet { get; set; }

        [Range(0, 1000000, ErrorMessage = "Paid Up Must be in Range 1 to 1000000")]
        public double PaidUp { get; set; }

        [NotMapped]
        public double BillRest { get; set; }


        [ForeignKey("Emp")]
        public int EmployeeId { get; set; }

        [ForeignKey("Clients")]
        public int ClientId { get; set; }

        //navegator
        public virtual Client Clients { get; set; }
        public virtual Employee Emp { get; set; }
        public virtual ICollection<IteamInvoice> Items_invoices { get; set; }


    }
}
