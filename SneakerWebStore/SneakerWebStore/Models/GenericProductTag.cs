using System.Collections.Generic;

namespace SneakerWebStore.Models
{
    public class GenericProductTag
    {
        public int GenericProductId { get; set; }

        public virtual GenericProduct GenericProduct{ get; set; }

        public short TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}