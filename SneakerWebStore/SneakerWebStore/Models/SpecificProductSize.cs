using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class SpecificProductSize
    {
        public int SpecificProductId { get; set; }
        public virtual SpecificProduct SpecificProduct { get; set; }


        public short SizeId { get; set; }
        public virtual Size Size { get; set; }

        public string Detail { get; set; }
    }
}
