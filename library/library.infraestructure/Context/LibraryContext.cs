using Microsoft.EntityFrameworkCore;
using library.domain.Entities;

namespace library.Infrastructure.Context
{
    public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
    {

        #region DbSets
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PubInfo> PubInfos { get; set; }
        #endregion

        #region Procedures
      
        #endregion
    }
}
