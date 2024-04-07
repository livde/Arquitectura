using System;
using library.api.Models;
using library.api.Dtos.PubInfo;

namespace library.application.Contracts
{
    public interface IPubInfoService : IBaseService<PubInfoAddDto, PubInfoUpdateDto, PubInfoRemoveDto, PubInfoGetModel>
    {
        object Save(PubInfoAddDto pubInfoAddDto);
        object Save(PubInfoAddDto pubInfoAddDto);
        object Update(PubInfoUpdateDto pubInfoUpdateDto);
        object Update(PubInfoUpdateDto pubInfoUpdateDto);
    }
}
