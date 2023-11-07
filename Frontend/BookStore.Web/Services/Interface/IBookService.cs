using BookStore.Web.Models.Dto;

namespace BookStore.Web.Services.Interface
{
    public interface IBookService
    {
        Task<ResponseDto?> GetAllBooksAsync();
        Task<ResponseDto?> GetBookByIdAsync(int id);
        Task<ResponseDto?> CreateBookAsync(BookDto bookDto);
        Task<ResponseDto?> UpdateBookAsync(BookDto bookDto);
        Task<ResponseDto?> DeleteBookAsync(int id);
    }
}
