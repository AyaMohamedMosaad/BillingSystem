using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.UI.Model
{
    public class ItemUnits
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Item")]
        public int ItemId { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Unit")]
        public int UnitId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Unit Unit { get; set; }

    }
}
