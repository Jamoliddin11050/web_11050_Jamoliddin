using _11050_workshop.Models;

namespace _11050_workshop.Repositories
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<publisher>> GetAllPublisher();
        
        Task<publisher> GetSinglepublisher(int id);
        Task Createpublisher(publisher publisher);
        Task Updatepublisher(publisher publisher);
        Task Deletepublisher(int id);
    }
}
