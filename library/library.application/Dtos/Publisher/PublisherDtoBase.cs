using System;

namespace library.Application.Dtos
{
    public class PublisherDtoBase:DtoBase
    {

        public string? Name { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }
}
