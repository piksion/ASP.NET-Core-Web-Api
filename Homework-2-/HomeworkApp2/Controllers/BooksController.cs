using HomeworkApp2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HomeworkApp2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		[HttpGet]
		public ActionResult<List<Book>> GetAllBooks()
		{
			try
			{
				return Ok(StaticDb.Books);
			}
			catch
			{
				return NotFound();
			}
		}
		[HttpGet("bookDetails")]
		public ActionResult<List<Book>> GetOneBook(int index)
		{
			try
			{
				if (index <= 0)
				{
					return BadRequest("Id can't be negative!");
				}
				Book booksDb = StaticDb.Books.FirstOrDefault(x => x.Id == index);
				if (index == null)
				{
					return NotFound($"Book with id {index} was not found!");
				}
				return Ok(booksDb);
			}
			catch
			{
				return NotFound();
			}
		}

		//Add GET method that returns one book by filtering by author and title (use query string parameters)
		[HttpGet("filteredBooks")]
		public ActionResult<List<Book>> FilteredBooks(string? author, string? title)
		{
			try
			{
				var books = StaticDb.Books;

				if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
				{
					return Ok(StaticDb.Books);
				}
				if (string.IsNullOrEmpty(title))
				{
					List<Book> bookDb = StaticDb.Books.Where(x => x.Author == author).ToList();
					return Ok(bookDb);
				}
				if (string.IsNullOrEmpty(author))
				{
					List<Book> bookDb = StaticDb.Books.Where(x => x.Title == title).ToList();
					return Ok(bookDb);
				}
				return Ok(books);
			}

			catch
			{
				return NotFound();
			}
		}

		[HttpPost]
		public IActionResult AddBook([FromBody] Book book)
		{
		
			try
			{
				if(string.IsNullOrEmpty(book.Title))
				{
					return BadRequest("You must specift Title");
				}
				if(string.IsNullOrEmpty(book.Author))
				{
					return BadRequest("You must speficy author");
				}
				StaticDb.Books.Add(book);
				return StatusCode(StatusCodes.Status201Created);

			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred");
			}

		}
	}
}
