using System;

namespace library.api.Models
{
    public class PubInfoGetModel
    {
        public int PubId { get; set; }
        public byte[]? Logo { get; set; }
        public string? PrInfo { get; set; }
    }
}
