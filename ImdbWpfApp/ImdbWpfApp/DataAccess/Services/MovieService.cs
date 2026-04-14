using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ImdbWpfApp.DataAccess;
using ImdbWpfApp.DataAccess.Services;

namespace ImdbWpfApp.Services
{
    public class MovieService
    {
        private readonly ImdbContext _context;

        public MovieService(ImdbContext context)
        {
            _context = context;
        }
        public MovieDetailsDto GetMovieDetails(string titleId)
        {


            var title = _context.Titles
                            .FirstOrDefault(t => t.TitleId == titleId);

            if (title == null)
                return null;

            var rating = _context.Ratings
                .FirstOrDefault(r => r.TitleId == titleId);


            var genres = (from tg in _context.TitleGenres
                          join g in _context.Genres
                              on tg.GenreId equals g.GenreId
                          where tg.TitleId == titleId
                          select g.Name)
                                      .ToList();

            var cast = (from p in _context.Principals
                        join n in _context.Names
                            on p.NameId equals n.NameId
                        where p.TitleId == titleId
                        select n.PrimaryName)
                        .ToList();




            return new MovieDetailsDto
            {
                Title = title.PrimaryTitle ?? "",
                Rating = rating?.AverageRating ?? 0,
                Votes = rating?.NumVotes?.ToString() ?? "0",
                Year = title.StartYear ?? 0,
                Runtime = $"{title.RuntimeMinutes ?? 0} min",
                Genres = genres,
                Cast = cast
            };



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
    };

      

}