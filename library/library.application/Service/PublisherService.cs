using library.application.Models.Publisher;
using library.Application.Contracts;
using library.Application.Core;
using library.Application.Dtos.Publisher;
using library.Application.Models;
using library.domain.Entities;
using library.Domain.Entities.Publisher;
using library.Infrastructure.Interfaces;
using Library.Application.Dtos.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;

namespace library.Application.Service
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _repository;
        private readonly ILoggerService _logger;

        public PublisherService(IPublisherRepository repository, ILoggerService logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public ServiceResult<IEnumerable<PublisherGetModel>> GetAll()
        {
            ServiceResult<IEnumerable<PublisherGetModel>> result = new ServiceResult<IEnumerable<PublisherGetModel>>();

            try
            {
                var publishers = _repository.GetEntities().Select(p => new PublisherGetModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Country = p.Country,
                    City = p.City,
                    CreationDate = p.CreationDate
                });

                result.Data = publishers;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los editores";
                _logger.LogError(result.Message + ex.Message);
            }
            return result;
        }

        public ServiceResult<PublisherGetModel> Get(int publisherId)
        {
            ServiceResult<PublisherGetModel> result = new ServiceResult<PublisherGetModel>();

            try
            {
                var publisher = _repository.GetEntity(publisherId);

                if (publisher == null)
                {
                    result.Success = false;
                    result.Message = "Editor no encontrado";
                    return result;
                }

                result.Data = new PublisherGetModel
                {
                    Id = publisher.Id,
                    Name = publisher.Name,
                    Country = publisher.Country,
                    City = publisher.City,
                    CreationDate = publisher.CreationDate
                };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el editor";
                _logger.LogError(result.Message + ex.Message);
            }

            return result;
        }

        public ServiceResult<PublisherGetModel> Save(PublisherAddDto publisherAddDto)
        {
            ServiceResult<PublisherGetModel> result = new ServiceResult<PublisherGetModel>();

            try
            {
                var publisher = new Publisher
                {
                    Name = publisherAddDto.Name,
                    Country = publisherAddDto.Country,
                    City = publisherAddDto.City,
                    CreationDate = DateTime.UtcNow // Asignamos la fecha actual
                };

                _repository.Save(publisher);

                result.Message = "Editor agregado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error agregando el editor";
                _logger.LogError(result.Message + ex.Message);
            }

            return result;
        }

        public ServiceResult<PublisherGetModel> Update(PublisherUpdateDto publisherUpdateDto)
        {
            ServiceResult<PublisherGetModel> result = new ServiceResult<PublisherGetModel>();

            try
            {
                var publisher = _repository.GetEntity(publisherUpdateDto.Id);

                if (publisher == null)
                {
                    result.Success = false;
                    result.Message = "Editor no encontrado";
                    return result;
                }

                publisher.Name = publisherUpdateDto.Name;
                publisher.Country = publisherUpdateDto.Country;
                publisher.City = publisherUpdateDto.City;

                _repository.Update(publisher);

                result.Message = "Editor actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el editor";
                _logger.LogError(result.Message + ex.Message);
            }

            return result;
        }

        public ServiceResult<PublisherGetModel> Remove(PublisherRemoveDto publisherRemoveDto)
        {
            ServiceResult<PublisherGetModel> result = new ServiceResult<PublisherGetModel>();

            try
            {
                var publisher = _repository.GetEntity(publisherRemoveDto.Id);

                if (publisher == null)
                {
                    result.Success = false;
                    result.Message = "Editor no encontrado";
                    return result;
                }

                _repository.Remove(publisher);

                result.Message = "Editor eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el editor";
                _logger.LogError(result.Message + ex.Message);
            }

            return result;
        }
    }
}
