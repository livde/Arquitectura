using Microsoft.Extensions.Logging;
using library.domain.Entities;
using library.Infrastructure.Context;
using library.Infrastructure.Core;
using library.Infrastructure.Interfaces;
using System.Linq;

namespace library.Infrastructure.Repositories
{
    public class PubInfoRepository : BaseRepository<PubInfo>, IPubInfoRepository
    {
        private new readonly LibraryContext _context;
        private readonly ILogger<PubInfoRepository> _logger;

        public PubInfoRepository(LibraryContext context, ILogger<PubInfoRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override void Save(PubInfo entity)
        {
            _context.PubInfos.Add(entity);
            _context.SaveChanges();
        }

        public override void Update(PubInfo entity)
        {
            _context.PubInfos.Update(entity);
            _context.SaveChanges();
        }

        public override void Remove(PubInfo entity)
        {
            _context.PubInfos.Remove(entity);
            _context.SaveChanges();
        }

       
    }
}
