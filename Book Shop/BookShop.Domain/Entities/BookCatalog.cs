using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Domain.Entities
{
    public class BookCatalog : BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int CatalogId { get; set; }


        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
        [ForeignKey(nameof(CatalogId))]
        public Catalog Catalog { get; set; }
    }
}
