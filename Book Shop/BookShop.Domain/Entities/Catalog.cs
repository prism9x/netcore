using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Entities
{
    public class Catalog : BaseEntity
    {
        [Required]
        [StringLength(500)]
        public string? Title
        { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        [Required]
        public bool IsAcvive { get; set; }
    }
}
