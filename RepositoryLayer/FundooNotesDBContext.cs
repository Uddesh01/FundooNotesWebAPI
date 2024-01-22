using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class FundooNotesDBContext : DbContext
    {
        public FundooNotesDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<UserEntity> Users { get; set; }

    }
}
