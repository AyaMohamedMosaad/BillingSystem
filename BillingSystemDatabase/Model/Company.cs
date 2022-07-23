using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BillingSystem.UI.Model
{
    public class Company
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Company Name is Required")]
        [StringLength(50, ErrorMessage = "Company Name Must be between 4 and 50 character", MinimumLength = 4)]
        public string CompanyName { get; set; }

        [MaxLength(250)]
        public string Notes { get; set; }


        //Navigation prpo
        public virtual ICollection<CompanyCategory> Companies { get; set; }


    }
}
