
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library.domain.Entities
{
    public class Publisher
    {
        [Key]
        
        public int pub_id { get; set; }
        public string? pub_name { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public  string? country { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
