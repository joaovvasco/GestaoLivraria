using GestaoLivraria.Communication;
using GestaoLivraria.Entities;
using GestaoLivraria.Enumeration;
using GestaoLivraria.Validation;
using Microsoft.AspNetCore.Mvc;

namespace GestaoLivraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private static readonly List<Book> books = new List<Book>();

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] BookRequestJson request)
        {
            BookValidator validator = new BookValidator();

            List<string> errors = validator.Validate(request);

            if (errors.Count > 0)
                return BadRequest(new ErrorResponseJson { messages = errors });

            Book book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Genre = request.Genre,
                Price = request.Price,
                Quantity = request.Quantity
            };

            books.Add(book);

            return Ok(book.Id);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<Book>),StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            if (books.Count <= 0)
                return NoContent();

            return Ok(books);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult Edit([FromRoute]Guid id, BookRequestJson request) 
        {

            Book? book = books.FirstOrDefault(book => book.Id == id);
            
            if (book == null)
                return NotFound();

            BookValidator validator = new BookValidator();
            List<string> errors = validator.Validate(request);

            if (errors.Count > 0)
                return BadRequest(new ErrorResponseJson { messages = errors });

            book.Title = request.Title; 
            book.Author = request.Author;
            book.Price = request.Price; 
            book.Quantity = request.Quantity;
            
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id) 
        {
            Book? book = books.FirstOrDefault(book => book.Id == id);

            if (book == null)
                return NotFound();

            books.Remove(book);

            return NoContent();
        }
    }
}
