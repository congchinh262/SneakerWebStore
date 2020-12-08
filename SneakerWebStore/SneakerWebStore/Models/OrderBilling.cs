using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class OrderBilling
    {
        public int Id { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(450)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(10)]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{10}$")]
        public string PhoneNumber { get; set; }

    }
}
