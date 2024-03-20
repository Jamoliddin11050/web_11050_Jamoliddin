using _11050_workshop.Data;
using _11050_workshop.Models;
using Microsoft.EntityFrameworkCore;

namespace _11050_workshop.Repositories
{
    public class PublishersRepository : IPublishersRepository
    {
        private readonly BookShopDbContext _dbContext;

        public PublishersRepository(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<publisher>> GetAllPublishers()
        {
            var publisher=  await _dbContext.publishers.ToListAsync();
             return publisher;
        }
        public async Task<publisher> GetSinglePublisher(int id)
        {
            return await _dbContext.publishers.FirstOrDefaultAsync(p => p.Id ==id);
        }
        public async Task CreatePublisher(publisher Publisher)
        {
            await _dbContext.publishers.AddAsync(Publisher);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePublisher(int id)
        {
            var Publisher = await _dbContext.publishers.FirstOrDefaultAsync(b => b.Id == id);
            if(Publisher != null)
            {
                _dbContext.publishers.Remove(Publisher);
                await _dbContext.SaveChangesAsync();


            }
        }

       
     

        public async Task UpdatePublisher(publisher Publisher)
        {
            _dbContext.Entry(Publisher).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<book>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<book> GetSingleBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateBook(book book)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBook(book book)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
