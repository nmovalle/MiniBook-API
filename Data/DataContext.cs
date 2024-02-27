using Microsoft.EntityFrameworkCore;
using MiniBook_API.Models;

namespace MiniBook_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<BookModel> Books { get; set; }
    }
}
