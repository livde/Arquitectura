using library.Application.Dtos;

namespace Library.Application.Dtos.Publisher
{
    public class PublisherUpdateDto:PublisherDtoBase
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
}
