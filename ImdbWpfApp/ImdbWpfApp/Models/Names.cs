namespace ImdbWpfApp.DataAccess
{
    public class Names
    {
        public string NameId { get; set; } = string.Empty;
        public string? PrimaryName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public string? PrimaryProfession { get; set; }
    }
}