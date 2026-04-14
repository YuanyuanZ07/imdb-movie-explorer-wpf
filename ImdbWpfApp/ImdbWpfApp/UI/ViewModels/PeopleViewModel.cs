using System.Collections.ObjectModel;
using ImdbWpfApp.DataAccess;
using ImdbWpfApp.Services;

namespace ImdbWpfApp.UI.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        private readonly PersonService _personService;

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

        public ObservableCollection<Names> People { get; set; } = new ObservableCollection<Names>();

        public PeopleViewModel()
        {
            var context = DbHelper.CreateContext();
            _personService = new PersonService(context);
        }

        public void LoadStarterPeople()
        {
            People.Clear();

            foreach (var person in _personService.GetStarterPeople())
            {
                People.Add(person);
            }
        }

        public void SearchPeople()
        {
            People.Clear();

            foreach (var person in _personService.SearchPeople(SearchKeyword))
            {
                People.Add(person);
            }
        }
    }
}