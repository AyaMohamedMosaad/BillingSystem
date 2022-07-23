using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BillingSystem.UI.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Category Name is Required")]
        [StringLength(50, ErrorMessage = "Company Name Must be between 6 and 50 character", MinimumLength = 6)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Notes { get; set; }


        //Nav prop
        public virtual ICollection<CompanyCategory> Categories { get; set; }
        public virtual ICollection<Item> Items { get; set; }



    }
}
