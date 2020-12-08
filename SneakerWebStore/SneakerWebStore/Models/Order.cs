using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string CustommerId { get; set; }

        public virtual ApplicationUser Custommer { get; set; }


        public DateTime OrderDate { get; set; }

        public short Status { get; set; }

        public short PaymentMethod { get; set; }

        public short PaymentStatus { get; set; }

        public short ShippingMethod { get; set; }

        public short ShippingStatus { get; set; }

        [Column(TypeName ="decimal(18,3)")]
        public decimal OrderTotal { get; set; }

        public virtual OrderBilling OrderBilling { get; set; }
        public virtual OrderShipping OrderShipping { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
