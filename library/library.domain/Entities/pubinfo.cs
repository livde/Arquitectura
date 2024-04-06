

using System.ComponentModel.DataAnnotations;

namespace library.domain.Entities
{
    public class PubInfo
    {

        [Key]
        public int pub_id { get; set; }
        public byte[]? Logo { get; set; }
        public string? PrInfo { get; set; }
    }
}