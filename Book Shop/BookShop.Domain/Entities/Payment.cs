using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Domain.Entities
{
    public class Payment : BaseEntity
    {
        [Required]
        [StringLength(15)]
        public string? Phone { get; set; }
        [Required]
        [StringLength(500)]
        public string? Address { get; set; }
        [Required]
        [StringLength(500)]
        public string? Fullname { get; set; }
        [Required]


        [StringLength(500)]
        public string? Email { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime CreateOn { get; set; }
        [Required]


        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AppUser? AppUser { get; set; }
    }
}
