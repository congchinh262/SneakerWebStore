using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class SpecificProduct
    {
        public int Id { get; set; }
        public int GenericProductId { get; set; }

        public virtual GenericProduct GenericProduct { get; set; }

        [Required]
        [StringLength(450)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal? Price { get; set; }

        public byte OrderType { get; set; }

        public byte Stock { get; set; }

        public bool IsBuyable { get; set; }

        public bool IsPreorderable { get; set; }

        [Required]
        [StringLength(450)]
        public string ImagePath { get; set; }

        public virtual ICollection<SpecificProductSize> SpecificProductSizes{ get; set; }
        public virtual ICollection<SpecificProductTag> SpecificProductTags{ get; set; }
        public virtual ICollection<SpecificProductImage> SpecificProductImages{ get; set; }
        public virtual ICollection<OrderDetail> OrderDetails{ get; set; }




    }
}
