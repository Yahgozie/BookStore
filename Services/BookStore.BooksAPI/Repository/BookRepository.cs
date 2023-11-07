using AutoMapper;
using BookStore.BooksAPI.Data;
using BookStore.BooksAPI.Models;
using BookStore.BooksAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace BookStore.BooksAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;

        public BookRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateBook(BookDto bookDto)
        {
            //Converting the bookDto model to a book model before creating
            Book createBook = _mapper.Map<BookDto, Book>(bookDto);
            _db.Books.Add(createBook);
            await _db.SaveChangesAsync();
            //Converting back the book model to the bookDto model after it is created and saved in the database 
            return _mapper.Map<Book, BookDto>(createBook);
        }

        public async Task<bool> DeleteBook(int bookId)
        {
            try
            {
                //Fetch the book using the id
                Book book = await _db.Books.Where(a => a.BookId == bookId).FirstOrDefaultAsync();
                if(book == null)
                {
                    return false;
                }
                _db.Books.Remove(book);
                await _db.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            //Get the list of books
            List<Book> bookList = await _db.Books.ToListAsync();
            //Convert the list of books to bookDto model by mapping it
            return _mapper.Map<List<BookDto>>(bookList);
        }

        public async Task<BookDto> GetBooksById(int bookId)
        {
            //Get the a single book based on its id
            Book book = await _db.Books.Where(a => a.BookId == bookId).FirstOrDefaultAsync();
            //Convert the single books to bookDto model by mapping it
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> UpdateBook(BookDto bookDto)
        {
            //Converting the bookDto model to a book model before updating
            Book createBook = _mapper.Map<BookDto, Book>(bookDto);
            _db.Books.Update(createBook);
            await _db.SaveChangesAsync();
            //Converting back the book model to the bookDto model after it is created and saved in the database 
            return _mapper.Map<Book, BookDto>(createBook);
        }
    }
}
