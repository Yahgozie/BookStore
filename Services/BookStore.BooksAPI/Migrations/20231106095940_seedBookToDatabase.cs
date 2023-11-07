using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.BooksAPI.Migrations
{
    public partial class seedBookToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "Religious", "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://res.cloudinary.com/dono96nzw/image/upload/v1587994686/35144_10650505_1969296_376a9d78_image_empuia.jpg", "Wing and prayer", 15m });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "SCI-FI", "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://res.cloudinary.com/dono96nzw/image/upload/v1587924642/e82fcc725b3bd2120dd4622370882507_usp76q.jpg", "Harry Potter", 13m });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "War", "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://res.cloudinary.com/dono96nzw/image/upload/v1587924635/book-cover-design-basic_xgkv5m.png", "Guy Kawasaki", 10m });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 4, "History", "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://res.cloudinary.com/dono96nzw/image/upload/v1587924635/book-cover-design-basic_xgkv5m.png", "Set for life", 15m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);
        }
    }
}
