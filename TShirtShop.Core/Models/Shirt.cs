using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TShirtShop.Core.Models
{
    public class Shirt : Entity
    {
        public int ShirtId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }
        public GenderEnum Gender { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [StringLength(500)]
        public string ImageLocation { get; set; }
        [StringLength(500)]
        public string ImageThumnNailLocation { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Sizes { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Genders { get; set; }
    }
}
