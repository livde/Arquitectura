namespace library.api.Dtos.PubInfo
{
    public class PubInfoUpdateDto : PubInfoDtoBase
    {
        // Identificador de la información pública a actualizar
        public int PubId { get; set; }
        // Propiedad para la información específica que se actualizará
        public byte[] Logo { get; set; }
        public string PrInfo { get; set; }
    }
}
