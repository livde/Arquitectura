namespace library.api.Dtos.PubInfo
{
    public class PubInfoAddDto : PubInfoDtoBase
    {
        // Propiedad para la información específica que se agregará
        public byte[]?Logo { get; set; }
        public string?PrInfo { get; set; }
    }
}
