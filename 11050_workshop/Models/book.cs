using _11050_workshop.Data;
using System.ComponentModel.DataAnnotations.Schema;
namespace _11050_workshop.Models
{
    public class book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int? PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public publisher? Publisher { get; set; }

    }



}
