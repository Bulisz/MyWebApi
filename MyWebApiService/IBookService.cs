using MyWebApiService.Model;

namespace MyWebApiService;

public interface IBookService
{
    Task DeleteBookAsync(Book book);
    Task<Book?> GetBookAsync(int id);
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> PostBookAsync(Book book);
    Task PutBookAsync(Book book);
}