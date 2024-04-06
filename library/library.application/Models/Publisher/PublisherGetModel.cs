using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.application.Models.Publisher
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

