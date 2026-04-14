using ImdbWpfApp.DataAccess;
using ImdbWpfApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace ImdbWpfApp.UI.ViewModels
{
    internal class MovieDetailsViewModel
    {


        public string Title { get; set; } = "";
        public double Rating { get; set; }
        public string Votes { get; set; } = "";
        public int Year { get; set; }
        public string Runtime { get; set; } = "";



        public ObservableCollection<string> Genres { get; set; } = new();
        public ObservableCollection<string> Cast { get; set; } = new();

        public MovieDetailsViewModel(string titleId)
        {

            using var context = new ImdbContext();
            var service = new MovieService(context);

            var movie = service.GetMovieDetails(titleId);

            if (movie == null)
                return;

            Title = string.Empty;
            Rating = 0.0;
            Votes = string.Empty;
            Year = 0;
            Runtime = string.Empty;
            Genres = new ObservableCollection<string>();
            Cast = new ObservableCollection<string>();

        }

    }
    }
