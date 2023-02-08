using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Models
{
    public class FoodOrder
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; private set; }

        [ForeignKey("Restaurant")]
        public int? RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; private set; }

        [ForeignKey("CustomerAddress")]
        public int? CustomerAddressId { get; set; }
        public virtual CustomerAddress CustomerAddress { get; private set; }

        [ForeignKey("OrderStatus")]
        public int? OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; private set; }

        [ForeignKey("Driver")]
        public int? AssignedDriverID { get; set; }
        public virtual Driver Driver { get; private set; }

        public DateTime OrderDateTime { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DeliverDateTime { get; set; }
        public int DriverRating { get; set; }
        public int RestaurantRating { get; set; }
    }
}
