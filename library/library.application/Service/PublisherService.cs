using library.application.Contracts;
using library.application.Core;
using library.application.Models.Publisher;
using library.domain.Entities;
using library.Infrastructure.Interfaces;
using Library.Application.Dtos.Publisher;
using System;
using System.Collections.Generic;

namespace library.application.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public ServiceResult<IEnumerable<PublisherGetModel>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<PublisherGetModel>>();
            try
            {
                var publishers = _publisherRepository.GetAll();
                // Mapping entities to DTOs
                var publisherDtos = MapEntitiesToDtos(publishers);
                result.Data = publisherDtos;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResult<PublisherGetModel> Get(int publisherId)
        {
            var result = new ServiceResult<PublisherGetModel>();
            try
            {
                var publisher = _publisherRepository.GetById(publisherId);
                if (publisher != null)
                {
                    // Mapping entity to DTO
                    var publisherDto = MapEntityToDto(publisher);
                    result.Data = publisherDto;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Publisher not found";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResult<PublisherGetModel> Save(PublisherAddDto publisherAddDto)
        {
            var result = new ServiceResult<PublisherGetModel>();
            try
            {
                var newPublisher = MapDtoToEntity(publisherAddDto);
                _publisherRepository.Save(newPublisher);
                result.Data = MapEntityToDto(newPublisher);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResult<PublisherGetModel> Update(PublisherUpdateDto publisherUpdateDto)
        {
            var result = new ServiceResult<PublisherGetModel>();
            try
            {
                var existingPublisher = _publisherRepository.GetById(publisherUpdateDto.PublisherId);
                if (existingPublisher != null)
                {
                    // Update entity properties
                    existingPublisher.pub_name = publisherUpdateDto.Name;
                    existingPublisher.city = publisherUpdateDto.City;
                    existingPublisher.state = publisherUpdateDto.State;
                    existingPublisher.country = publisherUpdateDto.Country;
                    _publisherRepository.Update(existingPublisher);
                    result.Data = MapEntityToDto(existingPublisher);
                }
                else
                {
                    result.Success = false;
                    result.Message = "Publisher not found";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResult<bool> Remove(PublisherRemoveDto publisherRemoveDto)
        {
            var result = new ServiceResult<bool>();
            try
            {
                var publisher = _publisherRepository.GetById(publisherRemoveDto.PublisherId);
                if (publisher != null)
                {
                    _publisherRepository.Remove(publisher);
                    result.Data = true;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Publisher not found";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;

        }



        // Helper method to map entities to DTOs
        private IEnumerable<PublisherGetModel> MapEntitiesToDtos(IEnumerable<Publisher> publishers)
        {
            var publisherDtos = new List<PublisherGetModel>();
            foreach (var publisher in publishers)
            {
                publisherDtos.Add(new PublisherGetModel
                {
                    PublisherId = publisher.pub_id,
                    Name = publisher.pub_name,
                    city = publisher.city,
                    state = publisher.state,
                    country = publisher.country,
                    CreationDate = publisher.CreationDate
                });
            }
            return publisherDtos;
        }

        // Helper method to map entity to DTO
        private PublisherGetModel MapEntityToDto(Publisher publisher)
        {
            return new PublisherGetModel
            {
                PublisherId = publisher.pub_id,
                Name = publisher.pub_name,
                city = publisher.city,
                state = publisher.state,
                country = publisher.country,
                CreationDate = publisher.CreationDate
            };
        }

        // Helper method to map DTO to entity
        private Publisher MapDtoToEntity(PublisherAddDto publisherAddDto)
        {
            return new Publisher
            {
                pub_name = publisherAddDto.Name,
                city = publisherAddDto.City,
                state = publisherAddDto.State,
                country = publisherAddDto.Country,
                CreationDate = DateTime.Now // Assuming creation date is set on creation
            };
        }
    }

}
