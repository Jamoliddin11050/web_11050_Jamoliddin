using _11050_workshop.Models;
using Microsoft.EntityFrameworkCore;

namespace _11050_workshop.Data
{
    public class BookShopDbContext:DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options):base(options) { }
    
          public DbSet<book>books { get; set; }
        public DbSet<publisher> publishers { get; set; }

    }   
}
