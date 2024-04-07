using library.Application.Dtos;

namespace library.api.Dtos.PubInfo
{
    public class PubInfoRemoveDto : DtoBase
    {
        // Identificador de la información pública a eliminar
        public int PubId { get; set; }
    }
}
