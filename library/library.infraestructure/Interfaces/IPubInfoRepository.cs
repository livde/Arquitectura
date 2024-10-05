using library.domain.Entities;
using System.Collections.Generic;

namespace library.Infrastructure.Interfaces
{
    public interface IPubInfoRepository
    {
        void Save(PubInfo entity);
        void Update(PubInfo entity);
        void Remove(PubInfo entity);
        IEnumerable<PubInfo> GetAll();
        PubInfo GetById(int id);
        
    }
}
