using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class OrderShipping
    {
        public int Id { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        [StringLength(450)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(450)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(450)]
        [Display(Name = "Address")]
        public string ShippingAddress { get; set; }

        [StringLength(10)]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{10}$")]
        public string PhoneNumber { get; set; }

    }
}
