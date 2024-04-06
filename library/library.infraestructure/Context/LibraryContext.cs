using Microsoft.EntityFrameworkCore;
using library.domain.Entities;
using library.Infrastructure.Core;

namespace library.Infrastructure.Context
{
    public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
    {

        #region DbSets
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PubInfo> PubInfos { get; set; }

        public BaseRepository<object> GetRepository<T>()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Procedures

        #endregion
    }
}
