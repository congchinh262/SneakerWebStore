using SneakerWebStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class GenericProduct
    {
        public int Id { get; set; }

        public short ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        [StringLength(450)]
        public string Name { get; set; }

        public string Details { get; set; }

        public virtual ICollection<GenericProductCategory> GenericProductCategories { get; set; }

        public virtual ICollection<GenericProductTag> GenericProductTags { get; set; }

        public virtual ICollection<SpecificProduct> SpecificProducts { get; set; }

    }
}
