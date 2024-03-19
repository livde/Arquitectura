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
        private new readonly LibraryContext _context;
        private readonly ILogger<PublisherRepository> _logger;

        public PublisherRepository(LibraryContext context, ILogger<PublisherRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override void Save(Publisher entity)
        {
            _context.Publishers.Add(entity);
            _context.SaveChanges();
        }

        public override void Update(Publisher entity)
        {
            _context.Publishers.Update(entity);
            _context.SaveChanges();
        }

        public override void Remove(Publisher entity)
        {
            _context.Publishers.Remove(entity);
            _context.SaveChanges();
        }

     
    }
}
