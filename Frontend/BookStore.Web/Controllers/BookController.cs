using BookStore.Web.Models.Dto;
using BookStore.Web.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;

namespace BookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> BookIndex()
        {
            CultureInfo nairaCulture = new CultureInfo("en-NG");
            nairaCulture.NumberFormat.CurrencySymbol = "₦";

            List<BookDto> books = new List<BookDto>();
            //responsedto was used because it is what is expected to be returned as output
            var response = await _bookService.GetAllBooksAsync();
            if(response != null && response.IsSuccess) {
                books = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Result));
            }
            return View(books);
        }

        public  ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(BookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.CreateBookAsync(bookDto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }          
            return View(bookDto);
        }

        public async Task<IActionResult> EditBook(int bookId)
        {
            var response = await _bookService.GetBookByIdAsync(bookId);
            if (response != null && response.IsSuccess)
            {
                //If book exists deserialize the book to the view so that it can be edited 
               BookDto books = JsonConvert.DeserializeObject<BookDto>(Convert.ToString(response.Result));
                return View(books);
            }
            return NotFound();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBook(BookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.UpdateBookAsync(bookDto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(bookDto);
        }

        public async Task<IActionResult> DeleteBook(int bookId)
        {
            //Fetch the book
            var response = await _bookService.GetBookByIdAsync(bookId);
            if (response != null && response.IsSuccess)
            {
                //If book exists deserialize the book to the view so that it can be edited 
                BookDto books = JsonConvert.DeserializeObject<BookDto>(Convert.ToString(response.Result));
                return View(books);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(BookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.DeleteBookAsync(bookDto.BookId);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(bookDto);
        }
    }
}
