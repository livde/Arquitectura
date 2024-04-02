using Microsoft.Extensions.Logging;
using library.domain.Entities;
using library.Infrastructure.Context;
using library.Infrastructure.Core;
using library.Infrastructure.Interfaces;
using System;
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

        // Métodos adicionales si es necesario

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
    }
}
