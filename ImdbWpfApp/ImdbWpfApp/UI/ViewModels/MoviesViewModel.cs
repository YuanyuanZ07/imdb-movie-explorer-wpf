using System.Collections.ObjectModel;
using ImdbWpfApp.DataAccess;
using ImdbWpfApp.Services;

namespace ImdbWpfApp.UI.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        private readonly MovieService _movieService;

        private string _searchKeyword = string.Empty;
        public string SearchKeyword
        {
            get => _searchKeyword;
            set
            {
                _searchKeyword = value;
                OnPropertyChanged();
            }
        }

        private string _selectedGenre = "All";
        public string SelectedGenre
        {
            get => _selectedGenre;
            set
            {
                _selectedGenre = value;
                OnPropertyChanged();
            }
        }

        private string _yearText = string.Empty;
        public string YearText
        {
            get => _yearText;
            set
            {
                _yearText = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Genres { get; set; } = new ObservableCollection<string>
        {
            "All",
            "Drama",
            "Comedy",
            "Action",
            "Romance",
            "Documentary"
        };

        public ObservableCollection<Titles> Movies { get; set; } = new ObservableCollection<Titles>();

        public MoviesViewModel()
        {
            var context = DbHelper.CreateContext();
            _movieService = new MovieService(context);
        }

        public void LoadStarterMovies()
        {
            Movies.Clear();

            foreach (var movie in _movieService.GetStarterMovies())
            {
                Movies.Add(movie);
            }
        }

        public void SearchMovies()
        {
            Movies.Clear();

            foreach (var movie in _movieService.SearchMovies(SearchKeyword))
            {
                Movies.Add(movie);
            }
        }

        public void FilterByYear()
        {
            Movies.Clear();

            if (short.TryParse(YearText, out short year))
            {
                foreach (var movie in _movieService.FilterByYear(year))
                {
                    Movies.Add(movie);
                }
            }
        }

        public void FilterByGenre()
        {
            Movies.Clear();

            foreach (var movie in _movieService.FilterByGenre(SelectedGenre))
            {
                Movies.Add(movie);
            }
        }
    }
}