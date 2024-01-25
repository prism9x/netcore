using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Domain.Entities
{
    public class Cart : BaseEntity
    {
        [StringLength(1000)]
        public string? Note { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public int Status { get; set; }
        [StringLength(250)]
        public string? Code { get; set; }


        [Required]
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AppUser? AppUser { get; set; }
    }
}
