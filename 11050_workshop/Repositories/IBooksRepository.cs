using _11050_workshop.Models;

namespace _11050_workshop.Repositories
{
    public interface IPublishersRepository
    {
        Task<IEnumerable<book>> GetAllBooks();
        
        Task<book> GetSingleBook(int id);
        Task CreateBook(book book);
        Task UpdateBook(book book);
        Task DeleteBook(int id);
    }
}
