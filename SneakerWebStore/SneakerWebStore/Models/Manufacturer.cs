using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class Manufacturer
    {
        public short Id { get; set; }

        [Required]
        [StringLength(450)]
        public string Name { get; set; }

        public virtual ICollection<GenericProduct> GenericProducts{ get; set; }
    }
}
