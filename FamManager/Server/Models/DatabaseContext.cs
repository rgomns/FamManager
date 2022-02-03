using FamManager.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FamManager.Server.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Shared.Models.Action> Actions { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shared.Models.Action>(entity =>
            {
                entity.ToTable("Action");
                entity.HasKey(c => c.Id);
                entity.Property(e => e.Title)
                    .HasMaxLength(254)
                    .IsRequired(true)
                    .IsUnicode(false);
                entity.Property(e => e.ImagePath)
                    .HasMaxLength(254)
                    .IsRequired(true)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}