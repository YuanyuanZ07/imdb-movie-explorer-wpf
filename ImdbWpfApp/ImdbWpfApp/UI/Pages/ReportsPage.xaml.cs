using System.Windows;
using System.Windows.Controls;
using ImdbWpfApp.UI.ViewModels;

namespace ImdbWpfApp.UI.Pages
{
    public partial class ReportsPage : Page
    {
        private readonly ReportsViewModel _viewModel;

        public ReportsPage()
        {
            InitializeComponent();
            _viewModel = new ReportsViewModel();
            DataContext = _viewModel;
        }

        private void LoadTopRatedButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadTopRatedMovies();
        }
    }
}