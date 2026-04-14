using System;
using System.Collections.Generic;
using System.Text;

namespace ImdbWpfApp.DataAccess.Services
{
    public class MovieDetailsDto
    {

        public string Title { get; set; } = "";
        public decimal Rating { get; set; }
        public string Votes { get; set; } = "";
        public int Year { get; set; }
        public string Runtime { get; set; } = "";

        public List<string> Genres { get; set; } = new();
        public List<string> Cast { get; set; } = new();
    }

}
