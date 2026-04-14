using Microsoft.EntityFrameworkCore;

namespace ImdbWpfApp.DataAccess
{
    public static class DbHelper
    {
        public static ImdbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer(
                    @"Server=(localdb)\ProjectModels;Database=IMDB;Trusted_Connection=True;TrustServerCertificate=True;",
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                        sqlOptions.CommandTimeout(120);
                    })
                .Options;

            return new ImdbContext(options);
        }
    }
}