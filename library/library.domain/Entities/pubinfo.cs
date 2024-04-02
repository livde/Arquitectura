

using System.ComponentModel.DataAnnotations;

namespace library.domain.Entities
{
    public class PubInfo
   {

        [Key]
        public int PubId { get; set; }
    public byte[]? Logo { get; set; }
    public string? PrInfo { get; set; }
}
}
