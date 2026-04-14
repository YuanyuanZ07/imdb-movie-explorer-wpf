namespace ImdbWpfApp.DataAccess
{
    public class Principals
    {
        public string TitleId { get; set; } = string.Empty;
        public int Ordering { get; set; }
        public string? NameId { get; set; }
        public string? JobCategory { get; set; }
        public string? Job { get; set; }
        public string? Characters { get; set; }
    }
}