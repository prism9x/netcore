using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        [StringLength(500)]
        public string? Fullname { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
