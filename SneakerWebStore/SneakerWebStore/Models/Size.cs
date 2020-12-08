using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class Size
    {
        public short Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Number { get; set; }

        public virtual ICollection<SpecificProductSize> SpecificProductSizes { get; set; }
    }
}
