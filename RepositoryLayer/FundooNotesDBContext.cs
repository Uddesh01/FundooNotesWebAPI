using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using RepositoryLayer.Entitys;

namespace RepositoryLayer
{
    public class FundooNotesDBContext : DbContext
    {
        public FundooNotesDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<UserEntity> Users { get; set; } 
        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<LabelEntity> Lables { get; set; }

    }
}
