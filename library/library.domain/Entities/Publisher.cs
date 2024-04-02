
using System.ComponentModel.DataAnnotations;

namespace library.domain.Entities
{
    public class Publisher
    {
        [Key]
        public int PubId { get; set; }
        public  string PubName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public  string Country { get; set; }
    }
}
