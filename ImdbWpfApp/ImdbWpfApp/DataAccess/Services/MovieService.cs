using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public List<Titles> GetStarterMovies()
        {
            return _context.Titles
                .AsNoTracking()
                .Where(t => t.TitleType == "movie" && t.PrimaryTitle != null)
                .Take(100)
                .ToList();
        }

        public List<Titles> SearchMovies(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return new List<Titles>();
            }

            keyword = keyword.Trim();

            return _context.Titles
                .AsNoTracking()
                .Where(t => t.TitleType == "movie"
                         && t.PrimaryTitle != null
                         && EF.Functions.Like(t.PrimaryTitle, $"%{keyword}%"))
                .Take(100)
                .ToList();
        }

        public List<Titles> FilterByYear(short year)
        {
            return _context.Titles
                .AsNoTracking()
                .Where(t => t.TitleType == "movie" && t.StartYear == year)
                .Take(100)
                .ToList();
        }

        public List<Titles> FilterByGenre(string genreName)
        {
            if (string.IsNullOrWhiteSpace(genreName) || genreName == "All")
            {
                return GetStarterMovies();
            }

            var query = from t in _context.Titles.AsNoTracking()
                        join tg in _context.TitleGenres.AsNoTracking() on t.TitleId equals tg.TitleId
                        join g in _context.Genres.AsNoTracking() on tg.GenreId equals g.GenreId
                        where t.TitleType == "movie"
                              && t.PrimaryTitle != null
                              && g.Name == genreName
                        select t;

            return query
                .Distinct()
                .Take(100)
                .ToList();
        }

        public List<TopRatedMovieDto> GetTopRatedMovies()
        {
            var query = from r in _context.Ratings.AsNoTracking()
                        join t in _context.Titles.AsNoTracking() on r.TitleId equals t.TitleId
                        where t.TitleType == "movie" && t.PrimaryTitle != null
                        orderby r.AverageRating descending, r.NumVotes descending
                        select new TopRatedMovieDto
                        {
                            PrimaryTitle = t.PrimaryTitle,
                            AverageRating = r.AverageRating,
                            NumVotes = r.NumVotes
                        };

            return query.Take(10).ToList();
        }
    }

    public class TopRatedMovieDto
    {
        public string? PrimaryTitle { get; set; }
        public decimal? AverageRating { get; set; }
        public int? NumVotes { get; set; }
    }
}