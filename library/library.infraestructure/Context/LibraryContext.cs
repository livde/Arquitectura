using Microsoft.EntityFrameworkCore;
using library.domain.Entities;

namespace library.Infrastructure.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        #region DbSets
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PubInfo> PubInfos { get; set; }
        #endregion

        #region Procedures
      
        #endregion
    }
}
