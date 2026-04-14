using System.Windows.Controls;
using ImdbWpfApp.UI.ViewModels;

namespace ImdbWpfApp.UI.Pages
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }
    }
}