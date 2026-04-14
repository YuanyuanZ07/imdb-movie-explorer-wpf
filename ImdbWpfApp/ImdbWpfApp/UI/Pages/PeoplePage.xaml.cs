using System.Windows;
using System.Windows.Controls;
using ImdbWpfApp.UI.ViewModels;

namespace ImdbWpfApp.UI.Pages
{
    public partial class PeoplePage : Page
    {
        private readonly PeopleViewModel _viewModel;

        public PeoplePage()
        {
            InitializeComponent();
            _viewModel = new PeopleViewModel();
            DataContext = _viewModel;
        }

        private void LoadStarterButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadStarterPeople();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SearchPeople();
        }
    }
}