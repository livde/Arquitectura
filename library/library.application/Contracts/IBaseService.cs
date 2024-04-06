using library.application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.application.Contracts
{
    public interface IBaseService<TDtoAdd, TDtoUpdate, TDtoRemove, TModel>
    {
        ServiceResult<IEnumerable<TModel>> GetAll();
        ServiceResult<TModel> Get(int publisherId);
        ServiceResult<TModel> Save(TDtoAdd publisherAddDto);
        ServiceResult<TModel> Update(TDtoUpdate publisherUpdateDto);
        ServiceResult<bool> Remove(TDtoRemove publisherRemoveDto);
    }
}

