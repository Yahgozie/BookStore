using BookStore.BooksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BooksAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

        //Seeding Book in the book database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 1,
                Name = "Wing and prayer",
                Price = 15,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://res.cloudinary.com/dono96nzw/image/upload/v1587994686/35144_10650505_1969296_376a9d78_image_empuia.jpg",
                CategoryName = "Religious"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 2,
                Name = "Harry Potter",
                Price = 13,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://res.cloudinary.com/dono96nzw/image/upload/v1587924642/e82fcc725b3bd2120dd4622370882507_usp76q.jpg",
                CategoryName = "SCI-FI"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 3,
                Name = "Guy Kawasaki",
                Price = 10,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://res.cloudinary.com/dono96nzw/image/upload/v1587924635/book-cover-design-basic_xgkv5m.png",
                CategoryName = "War"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 4,
                Name = "Set for life",
                Price = 15,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://res.cloudinary.com/dono96nzw/image/upload/v1587924635/book-cover-design-basic_xgkv5m.png",
                CategoryName = "History"
            });
        }
    }
}
