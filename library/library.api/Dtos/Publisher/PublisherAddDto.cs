using library.api.Dtos.Publisher;
using System;

namespace library.api.Dtos
{
    public class PublisherAddDto:PublisherDtoBase
    {
        public string? PublisherName { get; set; }
        public new string? City { get; set; }
        public new string? State { get; set; }
        public new string? Country { get; set; }
        
    }
}
