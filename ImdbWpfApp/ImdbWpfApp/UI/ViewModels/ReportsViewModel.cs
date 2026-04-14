using System.Collections.ObjectModel;
using ImdbWpfApp.DataAccess;
using ImdbWpfApp.Services;

namespace ImdbWpfApp.UI.ViewModels
{
    public class ReportsViewModel : BaseViewModel
    {
        private readonly MovieService _movieService;

        public ObservableCollection<TopRatedMovieDto> TopRatedMovies { get; set; } = new ObservableCollection<TopRatedMovieDto>();

        public ReportsViewModel()
        {
            var context = DbHelper.CreateContext();
            _movieService = new MovieService(context);
        }

        public void LoadTopRatedMovies()
        {
            TopRatedMovies.Clear();

            foreach (var item in _movieService.GetTopRatedMovies())
            {
                TopRatedMovies.Add(item);
            }
        }
    }
}