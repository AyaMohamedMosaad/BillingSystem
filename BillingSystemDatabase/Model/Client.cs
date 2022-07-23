
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.UI.Model
{
    public class Client
    {
        [Key]
        public int Number { get; set; }


        [Index(IsUnique = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Client Name is Required")]
        [StringLength(50, ErrorMessage = "Name Must be between 3 to 50 character", MinimumLength = 3)]
        public string Name { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Client Phone is Required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [StringLength(14, ErrorMessage = "Phone Must be 14 digit", MinimumLength = 14)]
        [RegularExpression("[0-9]{14}", ErrorMessage = "Phone Number is Not Valid")]
        public string Phone { get; set; }



        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }


        // Nav prop
        public virtual List<Invoice> Invoices { get; set; }



    }
}
