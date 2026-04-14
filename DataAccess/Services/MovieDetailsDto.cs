using System.Collections.Generic;

namespace final_project.Services
{
    public class MovieDetailsDto
    {
        public string Title { get; set; }
        public double Rating { get; set; }
        public string Votes { get; set; }
        public int Year { get; set; }
        public string Runtime { get; set; }

        public List<string> Genres { get; set; }
        public List<string> Cast { get; set; }
    }
}