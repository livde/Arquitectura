using Microsoft.Extensions.Logging;
using library.domain.Entities;
using library.Infrastructure.Context;
using library.Infrastructure.Core;
using library.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
                return _context.Publishers.ToList();
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
            throw new NotImplementedException();
        }

        


    }
}
