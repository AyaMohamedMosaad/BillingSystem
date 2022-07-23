using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.UI.Model
{
    public class Item
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Item Name is Required")]
        [StringLength(50, ErrorMessage = "Item Name Must be between 6 and 50 character", MinimumLength = 6)]
        public string Name { get; set; }

        [Range(1, 1000000, ErrorMessage = "The Price must be in Range from 1 to 1000000")]
        public decimal BuyingPrice { get; set; }

        [Range(1, 1000000, ErrorMessage = "The Price must be in Range from 1 to 1000000")]
        public decimal sellingPrice { get; set; }

        [MaxLength(250)]
        public string Notes { get; set; }

        //foreign keys
        [ForeignKey("Category")]
        public int CategoryId { set; get; }



        // Nav Prop
        public virtual Category Category { get; set; }
        public virtual ICollection<ItemUnits> Units { get; set; }
        public virtual ICollection<IteamInvoice> IteamInvoices { get; set; }


        //test comment
    }
}
