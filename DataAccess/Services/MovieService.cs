// MovieService with LINQ search/filter
using System.Collections.Generic;
using System.Linq;
using ImdbWpfApp.DataAccess;

namespace ImdbWpfApp.Services
{
    public class MovieService
    {
        private readonly ImdbContext _context;

        public MovieService(ImdbContext context)
        {
            _context = context;
        }

        // Get all movies
        public List<Titles> GetAllMovies()
        {
            return _context.Titles
                .OrderBy(t => t.PrimaryTitle)
                .Take(100)
                .ToList();
        }

        // Search by title
        public List<Titles> SearchMovies(string keyword)
        {
            return _context.Titles
                .Where(t => t.PrimaryTitle != null && t.PrimaryTitle.Contains(keyword))
                .OrderBy(t => t.PrimaryTitle)
                .ToList();
        }

        // Filter by year
        public List<Titles> FilterByYear(short year)
        {
            return _context.Titles
                .Where(t => t.StartYear == year)
                .ToList();
        }

        // Top rated movies
        public List<object> GetTopRatedMovies()
        {
            var query = _context.Ratings
                .OrderByDescending(r => r.AverageRating)
                .Take(10)
                .Join(_context.Titles,
                    r => r.TitleId,
                    t => t.TitleId,
                    (r, t) => new
                    {
                        t.PrimaryTitle,
                        r.AverageRating,
                        r.NumVotes
                    });

            return query.Cast<object>().ToList();
        }

        // Filter by genre
        public List<object> FilterByGenre(string genreName)
        {
            var query = from t in _context.Titles
                        join tg in _context.TitleGenres on t.TitleId equals tg.TitleId
                        join g in _context.Genres on tg.GenreId equals g.GenreId
                        where g.Name == genreName
                        select new
                        {
                            t.TitleId,
                            t.PrimaryTitle,
                            Genre = g.Name
                        };

            return query.Cast<object>().ToList();
        }
    }
}