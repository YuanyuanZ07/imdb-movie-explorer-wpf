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
    }
}
