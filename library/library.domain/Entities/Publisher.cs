
using System.ComponentModel.DataAnnotations;

namespace library.domain.Entities
{
    public class Publisher
    {
        [Key]
        public int pub_id { get; set; }
        public string pub_name { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public  string Country { get; set; }
    }
}
