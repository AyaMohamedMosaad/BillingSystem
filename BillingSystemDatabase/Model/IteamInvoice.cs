using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.UI.Model
{
    public class IteamInvoice
    {

       
        [ForeignKey("item")]
        public int item_id { get; set; }
        
        [ForeignKey("invoice")]
        public int invoice_id { get; set; }


        [Key]
        
        public int helper_pk { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int ItemsTotalPrice { get; set; }

        //navigators
        public virtual Item item { get; set; }
        public virtual Invoice invoice { get; set; }
    }
}
