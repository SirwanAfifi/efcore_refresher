using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class samuraiContext : DbContext
    {
        public samuraiContext()
        {
        }

        public samuraiContext(DbContextOptions<samuraiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clans> Clans { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }
        public virtual DbSet<Samuraies> Samuraies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=samurai.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clans>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.HasIndex(e => e.SamuraiId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Samurai)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.SamuraiId);
            });

            modelBuilder.Entity<Samuraies>(entity =>
            {
                entity.HasIndex(e => e.ClanId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Clan)
                    .WithMany(p => p.Samuraies)
                    .HasForeignKey(d => d.ClanId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
