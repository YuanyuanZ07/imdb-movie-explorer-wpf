using Microsoft.EntityFrameworkCore;

namespace ImdbWpfApp.DataAccess
{
    public class ImdbContext : DbContext
    {
        public ImdbContext(DbContextOptions<ImdbContext> options)
            : base(options)
        {
        }

        public DbSet<Titles> Titles { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<TitleGenres> TitleGenres { get; set; }
        public DbSet<Names> Names { get; set; }
        public DbSet<Principals> Principals { get; set; }
        public DbSet<Directors> Directors { get; set; }
        public DbSet<Writers> Writers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Titles>().HasKey(t => t.TitleId);
            modelBuilder.Entity<Ratings>().HasKey(r => r.TitleId);
            modelBuilder.Entity<Genres>().HasKey(g => g.GenreId);
            modelBuilder.Entity<TitleGenres>().HasKey(tg => new { tg.TitleId, tg.GenreId });
            modelBuilder.Entity<Names>().HasKey(n => n.NameId);
            modelBuilder.Entity<Principals>().HasKey(p => new { p.TitleId, p.Ordering });
            modelBuilder.Entity<Directors>().HasKey(d => new { d.TitleId, d.NameId });
            modelBuilder.Entity<Writers>().HasKey(w => new { w.TitleId, w.NameId });

            modelBuilder.Entity<Titles>().ToTable("Titles");
            modelBuilder.Entity<Ratings>().ToTable("Ratings");
            modelBuilder.Entity<Genres>().ToTable("Genres");
            modelBuilder.Entity<TitleGenres>().ToTable("Title_Genres");
            modelBuilder.Entity<Names>().ToTable("Names");
            modelBuilder.Entity<Principals>().ToTable("Principals");
            modelBuilder.Entity<Directors>().ToTable("Directors");
            modelBuilder.Entity<Writers>().ToTable("Writers");
        }
    }
}