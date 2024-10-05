using library.domain.Entities;

namespace library.Infrastructure.Interfaces
{
    public interface IPublisherRepository : IBaseRepository<Publisher>
    {
        bool Exists(Func<object, bool> value);
        IEnumerable<Publisher> GetAll();
        Publisher GetById(int id);
        IEnumerable<object> GetEntities();
        object GetEntity(int publisherId);
        void Remove(object existingPublisher);
        void Save(Publisher publisher);
        void Update(Publisher publisher);
    }
}
