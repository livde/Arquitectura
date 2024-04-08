using library.application.Core;

using library.application.Models.Publisher;
using Library.Application.Dtos.Publisher;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.Contracts
{
    public interface IPublisherService
    {
        Task<ServiceResult<IEnumerable<PublisherGetModel>>> GetAll();
        Task<ServiceResult<PublisherGetModel>> Get(int id);
        Task<ServiceResult<bool>> Save(PublisherAddDto publisher);
        Task<ServiceResult<bool>> Update(PublisherUpdateDto publisher);
        Task<ServiceResult<bool>> Remove(PublisherRemoveDto publisher);
    }
}
