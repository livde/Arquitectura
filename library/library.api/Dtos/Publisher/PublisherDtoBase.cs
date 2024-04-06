using library.Infrastructure.Dtos;

namespace library.api.Dtos.Publisher
{
    public class PublisherDtoBase : DtoBase
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }
}
