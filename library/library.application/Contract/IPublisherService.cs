using library.application.Dtos.Publisher;
using library.application.Models.Publisher;
using Library.Application.Dtos.Publisher;
using Library.Application.Models.Publisher;
using Library.Domain.Service;

namespace Library.Application.Contracts
{
    public interface IPublisherService : IBaseService<PublisherAddDto, PublisherUpdateDto, PublisherDeleteDto, PublisherGetModel>
    {
    }
}
