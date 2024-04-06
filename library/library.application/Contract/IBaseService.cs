namespace library.Domain.Services
{
    public interface IPublisherService : IBaseService<PublisherDtoAdd, PublisherDtoUpdate, PublisherDtoRemove, Publisher>
    {
        ServiceResult<IEnumerable<Publisher>> GetAll();
        ServiceResult<Publisher> Get(int publisherId);
        ServiceResult<Publisher> Save(PublisherDtoAdd publisherAddDto);
        ServiceResult<Publisher> Update(PublisherDtoUpdate publisherUpdateDto);
        ServiceResult<Publisher> Remove(PublisherDtoRemove publisherRemoveDto);
    }
}