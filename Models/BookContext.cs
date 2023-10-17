using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Models
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions<BookContext> options):base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
        public DbSet<FileDescribe> FileDescribe { get; set; } 
    }
}
