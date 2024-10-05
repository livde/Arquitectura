using System;
using library.api.Dtos;

namespace library.Infrastructure.Dtos
{
    public class PublisherDto : DtoBase
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
