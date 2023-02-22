
using Microsoft.EntityFrameworkCore;
using MyWebApiService.Model;

namespace MyWebApiService;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
