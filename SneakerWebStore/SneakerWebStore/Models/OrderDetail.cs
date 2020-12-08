using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int SpecificProductId { get; set; }

        public virtual SpecificProduct SpecificProduct { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal? Price { get; set; }

        public string Size { get; set; }

        public short? Quantity { get; set; }

    }
}
