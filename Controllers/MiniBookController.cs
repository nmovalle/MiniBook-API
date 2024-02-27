using Microsoft.AspNetCore.Mvc;
using MiniBook_API.Data;
using MiniBook_API.Models;

namespace MiniBook_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MiniBookController : Controller
    {
        private static List<BookModel> bookList = new List<BookModel>();

        [HttpGet(Name = "GetBooks")]
        public IActionResult GetBooks()
        {
            BookModel book = new BookModel
            {
                Id = 1,
                Title = "The Two Towers",
                Description = string.Empty,
                Author = "xxx",
                Created = DateTime.Now
            };

            bookList.Add(book);
            return Ok(bookList);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = bookList.Find(x => x.Id == id);
            if (book is null)
                return NotFound("Libro no encontrado.");


            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(BookModel book)
        {
            bookList.Add(book);

            return Ok(bookList);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookModel updatedBook)
        {
            var book = bookList.Find(x => x.Id == id);
            if (book is null)
                return NotFound("Libro no encontrado.");

            book.Title = updatedBook.Title;
            book.Description = updatedBook.Description;
            book.Author = updatedBook.Author;
            book.Created = DateTime.Now;

            return Ok(bookList);
        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var book = bookList.Find(x => x.Id == id);
            if (book is null)
                return NotFound("Libro no encontrado.");

            bookList.Remove(book);

            return Ok(bookList);
        }
    }
}
