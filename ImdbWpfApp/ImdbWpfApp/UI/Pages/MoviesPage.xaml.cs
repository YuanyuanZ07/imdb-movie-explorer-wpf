using System.Windows;
using System.Windows.Controls;
using ImdbWpfApp.UI.ViewModels;

namespace ImdbWpfApp.UI.Pages
{
    public partial class MoviesPage : Page
    {
        private readonly MoviesViewModel _viewModel;

        public MoviesPage()
        {
            InitializeComponent();
            _viewModel = new MoviesViewModel();
            DataContext = _viewModel;
        }

        private void LoadStarterButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadStarterMovies();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SearchMovies();
        }

        private void FilterYearButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.FilterByYear();
        }

        private void FilterGenreButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.FilterByGenre();
        }
    }
}