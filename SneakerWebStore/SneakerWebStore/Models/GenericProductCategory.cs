using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class GenericProductCategory
    {
        public int GenericProductId { get; set; }

        public virtual GenericProduct GenericProduct { get; set; }

        public short CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
