using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerWebStore.Models
{
    public class SpecificProductImage
    {
        public int Id { get; set; }

        public int SpecificProductId { get; set; }

        public virtual SpecificProduct SpecificProduct { get; set; }

        //sap xep anh
        public short Order { get; set; }

        [Required]
        [StringLength(450)]
        public string ImagePath { get; set; }
    }
}
