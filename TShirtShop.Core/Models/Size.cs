using System.ComponentModel.DataAnnotations;

namespace TShirtShop.Core.Models
{
    public class Size : Entity
    {
        public int SizeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
