
namespace library.domain.Entities
{
    public class Publisher
    {
        public int PubId { get; set; }
        public required string PubName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public required string Country { get; set; }
    }
}
