using System.ComponentModel.DataAnnotations;

namespace BookStore.BooksAPI.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
