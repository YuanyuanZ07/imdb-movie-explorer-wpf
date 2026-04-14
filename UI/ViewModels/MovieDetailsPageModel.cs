using System.Collections.ObjectModel;
using final_project.Services;

namespace final_project.ViewModels
{
    public class MovieDetailsPageModel
    {
        private readonly MovieService _movieService;

        public string Title { get; set; }
        public double Rating { get; set; }
        public string Votes { get; set; }
        public int Year { get; set; }
        public string Runtime { get; set; }

        public ObservableCollection<string> Genres { get; set; }
        public ObservableCollection<string> Cast { get; set; }

        public MovieDetailsPageModel(string titleId)
        {
            _movieService = new MovieService(new DataAccess.ImdbContext());

            var movie = _movieService.GetMovieDetails(titleId);

            Title = movie.Title;
            Rating = movie.Rating;
            Votes = movie.Votes;
            Year = movie.Year;
            Runtime = movie.Runtime;

            Genres = new ObservableCollection<string>(movie.Genres);
            Cast = new ObservableCollection<string>(movie.Cast);
        }
    }
}
