using library.domain.Entities;

namespace library.Infrastructure.Interfaces
{
    public interface IPublisherRepository : IBaseRepository<Publisher>
    {
        object GetAll();
        object GetById(int id);
        void Remove(object existingPublisher);
        void Save(Publisher publisher);
        void Update(Publisher publisher);
    }
}
