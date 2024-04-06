using library.api.Dtos.Publisher;

namespace library.Infrastructure.Dtos
{
    public class PublisherUpdateDto:PublisherDtoBase
    {
        public int PublisherId { get; set; }
        public new string? Name { get; set; }
        public new string? City { get; set; }
        public new string? State { get; set; }
        public new string? Country { get; set; }
    }
}
