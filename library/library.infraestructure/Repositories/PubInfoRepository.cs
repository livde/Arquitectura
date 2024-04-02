using Microsoft.Extensions.Logging;
using library.domain.Entities;
using library.Infrastructure.Context;
using library.Infrastructure.Core;
using library.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace library.Infrastructure.Repositories
{
    public class PubInfoRepository : BaseRepository<PubInfo>, IPubInfoRepository
    {
        private readonly LibraryContext _context;
        private readonly ILogger<PubInfoRepository> _logger;

        public PubInfoRepository(LibraryContext context, ILogger<PubInfoRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override void Save(PubInfo entity)
        {
            try
            {
                _context.PubInfos.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al guardar PubInfo", ex);
            }
        }

        public override void Update(PubInfo entity)
        {
            try
            {
                _context.PubInfos.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al actualizar PubInfo", ex);
            }
        }

        public override void Remove(PubInfo entity)
        {
            try
            {
                _context.PubInfos.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al eliminar PubInfo", ex);
            }
        }
    }
}
