using Microsoft.Extensions.Logging;
using library.domain.Entities;
using library.Infrastructure.Context;
using library.Infrastructure.Core;
using library.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace library.Infrastructure.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        private readonly LibraryContext _context;
        private readonly ILogger<PublisherRepository> _logger;

        public PublisherRepository(LibraryContext context, ILogger<PublisherRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override void Save(Publisher entity)
        {
            try
            {
                _context.Publishers.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al guardar el editor", ex);
            }
        }

        public override void Update(Publisher entity)
        {
            try
            {
                _context.Publishers.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al actualizar el editor", ex);
            }
        }

        public override void Remove(Publisher entity)
        {
            try
            {
                _context.Publishers.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al eliminar el editor", ex);
            }
        }

        public IEnumerable<Publisher> GetAll()
        {
            try
            {
                return _context.Publishers.Select(p => new Publisher
                {
                    pub_id = p.pub_id,
                    pub_name = p.pub_name,
                    city = p.city,
                    state = p.state,
                    country = p.country,
                    CreationDate = p.CreationDate
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al obtener todos los editores", ex);
                throw;
            }
        }

        public Publisher GetById(int id)
        {
            try
            {
                return _context.Publishers.Find(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al obtener el editor por id", ex);
                throw;
            }
        }


        public void Remove(object existingPublisher)
        {
            try
            {
                // Busca la entidad del editor a eliminar
                var entityToRemove = _context.Publishers.FirstOrDefault(p => p.pub_id == ((Publisher)existingPublisher).pub_id);

                // Si se encuentra la entidad, la elimina
                if (entityToRemove != null)
                {
                    _context.Publishers.Remove(entityToRemove);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al eliminar el editor", ex);
            }
        }



        public bool Exists(Func<object, bool> predicate)
        {
            return _context.Publishers.Any(predicate);
        }

        public IEnumerable<object> GetEntities()
        {
            return _context.Publishers.Select(p => new
            {
                pub_id = p.pub_id,
                pub_name = p.pub_name,
                city = p.city,
                state = p.state,
                country = p.country,
                CreationDate = p.CreationDate
            });
        }

        public object GetEntity(int id)
        {
            return _context.Publishers.Find(id);
        }
    }
}
