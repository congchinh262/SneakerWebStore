using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class Tag
    {
        public short Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public byte Type { get; set; }

        public virtual ICollection<GenericProductTag> GenericProductTags { get; set; }

        public virtual ICollection<SpecificProductTag> SpecificProductTags { get; set; }

    }
}
