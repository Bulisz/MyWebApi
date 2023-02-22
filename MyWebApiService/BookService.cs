using Microsoft.EntityFrameworkCore;
using MyWebApiService.Model;

namespace MyWebApiService;

public class BookService : IBookService
{
    private readonly AppDbContext _appDbContext;

    public BookService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await _appDbContext.Books.ToListAsync();
    }

    public async Task<Book> PostBookAsync(Book book)
    {
        _appDbContext.Books.Add(book);
        await _appDbContext.SaveChangesAsync();
        return book;
    }

    public async Task<Book?> GetBookAsync(int id)
    {   
        Book? book = await _appDbContext.Books.FindAsync(id);
        if (book is not null)
            _appDbContext.Entry(book).State = EntityState.Detached;
        return book;
    }

    public async Task PutBookAsync(Book book)
    {
        _appDbContext.Update(book);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(Book book)
    {
        _appDbContext.Books.Remove(book);
        await _appDbContext.SaveChangesAsync();
    }
}
