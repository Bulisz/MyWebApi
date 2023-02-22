using Microsoft.AspNetCore.Mvc;
using MyWebApiService;
using MyWebApiService.Model;

namespace MyWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase, IBooksController
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    // GET: api/Books
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        IEnumerable<Book> books = await _bookService.GetBooksAsync();

        if (!books.Any())
        {
            return NotFound();
        }

        return books.ToList();
    }

    // POST: api/Books
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(Book book)
    {
        Book bookToAdd = await _bookService.PostBookAsync(book);
        return CreatedAtAction("GetBook", new { id = bookToAdd.Id }, bookToAdd);
    }

    // GET: api/Books/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        Book? book = await _bookService.GetBookAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    // PUT: api/Books/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, Book book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }

        if (!await BookExists(id))
        {
            return NotFound();
        }

        await _bookService.PutBookAsync(book);
        return NoContent();
    }

    // DELETE: api/Books/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _bookService.GetBookAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        await _bookService.DeleteBookAsync(book);

        return NoContent();
    }

    private async Task<bool> BookExists(int id)
    {
        return await _bookService.GetBookAsync(id) is not null;
    }
}
