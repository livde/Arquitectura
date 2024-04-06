using library.application.Core;
using library.application.Models.Publisher;
using Library.Application.Dtos.Publisher; 
namespace library.application.Contracts
{
    public interface IPublisherService : IBaseService<PublisherAddDto, PublisherUpdateDto, PublisherRemoveDto, PublisherGetModel>
    {
    }
}
