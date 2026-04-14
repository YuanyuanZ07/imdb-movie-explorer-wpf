namespace ImdbWpfApp.DataAccess
{
    public class Titles
    {
        public string TitleId { get; set; } = string.Empty;
        public string? TitleType { get; set; }
        public string? PrimaryTitle { get; set; }
        public string? OriginalTitle { get; set; }
        public bool? IsAdult { get; set; }
        public short? StartYear { get; set; }
        public short? EndYear { get; set; }
        public short? RuntimeMinutes { get; set; }
    }
}