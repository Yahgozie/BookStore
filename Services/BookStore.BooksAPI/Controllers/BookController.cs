using BookStore.BooksAPI.Models.Dto;
using BookStore.BooksAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.BooksAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        protected ResponseDto _response;
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("getAllBooks")]
        public async Task<object> Get()
        {
            try
            {
                //Get the list of books
                IEnumerable<BookDto> bookDtos = await _bookRepository.GetBooks();
                //return the response as books if successful
                _response.Result = bookDtos;
            }
            catch (Exception ex)
            {
                //if the response is unsuccessful
                _response.IsSuccess = false;
                //Display error messages
                _response.Message = ex.Message;                
            }
            //return the final response based on if it is successful or unsuccessful.
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<object> Get(int id)
        {
            try
            {          
                BookDto bookDtos = await _bookRepository.GetBooksById(id);             
                _response.Result = bookDtos;
            }
            catch (Exception ex)
            {                
                _response.IsSuccess = false;              
                _response.Message = ex.Message;
            }          
            return _response;
        }

        [HttpPost]
        [Route("createBook")]
        public async Task<object> Post([FromBody]BookDto bookDto)
        {
            try
            {
                //Get the repository for creating books
                BookDto bookDtos = await _bookRepository.CreateBook(bookDto);              
                _response.Result = bookDtos;
            }
            catch (Exception ex)
            {             
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }       
            return _response;
        }

        [HttpPut]
        [Route("updateBook")]
        public async Task<object> Put([FromBody] BookDto bookDto)
        {
            try
            {
                //Get the repository for updating books
                BookDto bookDtos = await _bookRepository.UpdateBook(bookDto);
                _response.Result = bookDtos;
            }
            catch (Exception ex)
            {             
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("deletebook/{id:int}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool bookDtos = await _bookRepository.DeleteBook(id);
                _response.Result = bookDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
