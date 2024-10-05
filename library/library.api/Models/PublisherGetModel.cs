using System;

namespace library.api.Models
{
    public class PublisherGetModel
    {
        public int PublisherId { get; set; }
        public string? Name { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
