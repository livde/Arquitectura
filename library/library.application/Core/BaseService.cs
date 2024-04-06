namespace library.Application.Core
{
    public abstract class BaseService<TEntity> where TEntity : class
    {
        private readonly BaseRepository<TEntity> repository;

        public BaseService(LibraryContext context)
        {
            this.repository = new BaseRepository<TEntity>(context);
        }

        public virtual ServiceResult<IEnumerable<TEntity>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<TEntity>>();

            result.Data = repository.GetEntities();

            return result;
        }

        public virtual ServiceResult<TEntity> GetById(dynamic id)
        {
            var result = new ServiceResult<TEntity>();

            result.Data = repository.GetEntity(id);

            return result;
        }

        public virtual ServiceResult<int> Remove(TEntity entity)
        {
            var result = new ServiceResult<int>();

            repository.Remove(entity);
            result.Success = true; // Assuming removal is successful
            return result;
        }

        public virtual ServiceResult<TEntity> Save(TEntity entity)
        {
            var result = new ServiceResult<TEntity>();

            repository.Save(entity);
            result.Data = entity; // Assuming the saved entity is returned
            return result;
        }

        public virtual ServiceResult<int> Update(TEntity entity)
        {
            var result = new ServiceResult<int>();

            repository.Update(entity);
            result.Success = true; // Assuming update is successful
            return result;
        }
    }
}
