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
<<<<<<< HEAD
=======
        public DbSet<NoteLabelEntity> NoteLabels { get; set; }
>>>>>>> 896f895f42d09d1f10c9f51804d233948b59fa77

    }
}
