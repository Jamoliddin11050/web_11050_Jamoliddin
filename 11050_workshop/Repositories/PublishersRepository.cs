using _11050_workshop.Data;
using _11050_workshop.Models;
using Microsoft.EntityFrameworkCore;

namespace _11050_workshop.Repositories
{
    public class BooksRepository : IPublishersRepository
    {
        private readonly BookShopDbContext _dbContext;

        public BooksRepository(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<book>> GetAllBooks()
        {
            var books=  await _dbContext.books.Include(b=>b.Publisher).ToListAsync();
             return books;
        }
        public async Task<book> GetSingleBook(int id)
        {
            return await _dbContext.books.Include(b => b.Publisher).FirstOrDefaultAsync(b => b.Id ==id);
        }
        public async Task CreateBook(book book)
        {
            await _dbContext.books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _dbContext.books.FirstOrDefaultAsync(b => b.Id == id);
            if(book != null)
            {
                _dbContext.books.Remove(book);
                await _dbContext.SaveChangesAsync();


            }
        }

       
     

        public async Task UpdateBook(book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
