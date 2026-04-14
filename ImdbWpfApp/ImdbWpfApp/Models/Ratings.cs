namespace ImdbWpfApp.DataAccess
{
    public class Ratings
    {
        public string TitleId { get; set; } = string.Empty;
        public decimal? AverageRating { get; set; }
        public int? NumVotes { get; set; }
    }
}