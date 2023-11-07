using BookStore.BooksAPI.Models.Dto;

namespace BookStore.BooksAPI.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> GetBooks();
        Task<BookDto> GetBooksById(int bookId);
        Task<BookDto> CreateBook(BookDto bookDto);
        Task<BookDto> UpdateBook(BookDto bookDto);
        Task<bool> DeleteBook(int bookId);
    }
}
