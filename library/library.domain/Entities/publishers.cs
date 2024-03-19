using library.domain.Entities;

namespace library.domain.Entities
{
    public class Publisher
    {
        public int PubId { get; set; }
        public string PubName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string Country { get; set; }
    }
}
