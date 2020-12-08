using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class ApplicationUser:IdentityUser
    {
        [StringLength(256)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(256)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
