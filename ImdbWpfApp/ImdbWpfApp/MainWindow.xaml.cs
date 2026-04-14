using System.Windows;
using ImdbWpfApp.UI.Pages;

namespace ImdbWpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new HomePage());
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
        }

        private void MoviesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MoviesPage());
        }

        private void PeopleButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PeoplePage());
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportsPage());
        }
    }
}