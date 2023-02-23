using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Models
{
    public class OrderMenuItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FoodOrder")]
        public int FoodOrderId { get; set; }
        public virtual FoodOrder FoodOrder { get; set; }
        
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; private set; }

        public int QuantityOrdered { get; set; }
    }
}
