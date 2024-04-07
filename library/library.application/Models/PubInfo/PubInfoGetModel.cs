using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace library.api.Models
{
    public class PubInfoGetModel
    {
        public int PubId { get; set; }
        public byte[]? Logo { get; set; }
        public string? PrInfo { get; set; }
    }
}

