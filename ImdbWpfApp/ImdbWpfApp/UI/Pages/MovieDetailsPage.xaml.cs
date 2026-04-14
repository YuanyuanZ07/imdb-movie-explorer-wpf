
using System.Windows;
using System.Windows.Controls;
using ImdbWpfApp.UI.ViewModels;

namespace ImdbWpfApp.UI.Pages
{
    /// <summary>
    /// Interação lógica para MovieDetailsPage.xam
    /// </summary>
    public partial class MovieDetailsPage : Page
    {
        private readonly MovieDetailsViewModel _viewModel;

        public MovieDetailsPage(string titleId)
        {
            InitializeComponent();
            _viewModel = new MovieDetailsViewModel(titleId);
            DataContext = _viewModel;
        }
    }
}
