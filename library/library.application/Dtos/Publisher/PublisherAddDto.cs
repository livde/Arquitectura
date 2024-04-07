using library.Application.Dtos;

namespace Library.Application.Dtos.Publisher
{
    public class PublisherAddDto:PublisherDtoBase
    {
        
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
