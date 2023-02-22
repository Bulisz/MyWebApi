using Microsoft.AspNetCore.Mvc;
using MyWebApiService.Model;

namespace MyWebApi.Controllers;

public interface IBooksController
{
    Task<IActionResult> DeleteBook(int id);
    Task<ActionResult<Book>> GetBook(int id);
    Task<ActionResult<IEnumerable<Book>>> GetBooks();
    Task<ActionResult<Book>> PostBook(Book book);
    Task<IActionResult> PutBook(int id, Book book);
}