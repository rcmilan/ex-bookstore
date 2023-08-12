using BookstoreApp.DTOs;
using BookstoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static readonly IEnumerable<Book> loremIpsumBooks = new Book[] // simula busca no DB
        {
            Book.Create("Rhetoric", Person.Create("Aristotle")),
            Book.Create("Das Kapital", Person.Create("Karl", "Marx")),
            Book.Create("Communist Manifesto", Person.Create("Karl", "Marx"), Person.Create("Friedrich", "Engels")),
            Book.Create("1001 Nights"),
        };

        [HttpGet]
        public IActionResult Get()
        {
            var result = loremIpsumBooks.ToBookHeaders();

            return Ok(result);
        }

        [HttpPost("Borrow")]
        public IActionResult Borrow([FromServices] BorrowingSystem borrowingSystem, int bookId)
        {
            var book = loremIpsumBooks.ToArray()[bookId]!;

            borrowingSystem.Borrow(book);

            return Ok();
        }
    }
}
