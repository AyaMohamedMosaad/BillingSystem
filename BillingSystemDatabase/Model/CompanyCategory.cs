using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.UI.Model
{
    public class CompanyCategory
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }


        // Navigation prop
        public virtual Company Company { get; set; }
        public virtual Category Category { get; set; }
    }
}
