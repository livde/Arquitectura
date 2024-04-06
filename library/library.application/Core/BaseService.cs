using library.application.Core; 
using library.domain.Entities; 
using library.Infrastructure.Context;
using library.Infrastructure.Core;

namespace library.application.Core
{
    public abstract class BaseService<TEntity> where TEntity : class
    {
        private readonly BaseRepository<TEntity> _repository;

        public BaseService(LibraryContext context)
        {
            
        }

        public virtual ServiceResult<IEnumerable<TEntity>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<TEntity>>();
            result.Data = _repository.GetAll();
            return result;
        }

        public virtual ServiceResult<TEntity> GetById(int id)
        {
            var result = new ServiceResult<TEntity>();
            result.Data = _repository.GetById(id);
            return result;
        }

        public virtual ServiceResult<bool> Remove(TEntity entity)
        {
            var result = new ServiceResult<bool>();
            _repository.Remove(entity);
            result.Data = true; // Assuming successful removal indicates true
            return result;
        }

        public virtual ServiceResult<TEntity> Save(TEntity entity)
        {
            var result = new ServiceResult<TEntity>();
            _repository.Save(entity);
            result.Data = entity; // Assuming saved entity is returned
            return result;
        }

        public virtual ServiceResult<TEntity> Update(TEntity entity)
        {
            var result = new ServiceResult<TEntity>();
            _repository.Update(entity);
            result.Data = entity; // Assuming updated entity is returned
            return result;
        }
    }
}
