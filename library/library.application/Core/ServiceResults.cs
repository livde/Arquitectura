using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.application.Core
{
    public class PublisherResult<TData>
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public TData? Data { get; set; }
    }
}