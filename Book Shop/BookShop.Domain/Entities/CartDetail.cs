using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Domain.Entities
{
    public class CartDetail : BaseEntity
    {
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [StringLength(500)]
        public string? Note { get; set; }

        [Required]
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }


        [Required]
        public int CartId { get; set; }
        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
    }
}
