using System.Collections;
using System.Collections.Generic;

namespace SneakerWebStore.Models
{
    public class SpecificProductTag
    {
        public int SpecificProductId { get; set; }

        public virtual SpecificProduct SpecificProduct { get; set; }

        public short TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}