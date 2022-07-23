using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.UI.Model
{
    public class Unit
    {

        public int ID { get; set; }

        [Index(IsUnique = true)]
        [Required(ErrorMessage = "Unit name is Required")]
        [StringLength(20, ErrorMessage = "Unint Name Must be between 2 to 20 character", MinimumLength = 2)]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Please Enter a vaild Unit Name")]
        public string Unit_Name { get; set; }

        [MaxLength(250)]
        public string Notes { get; set; }


        //Navigation prpo
        public virtual ICollection<ItemUnits> ItemUnits { get; set; }


    }
}
