namespace BookManager.App.Models.Authors
{
    public class UpdateAuthorInputModel
    {
        public string? Name { get; set; }
        public string? Nationality { get; set; }
        public DateTime? BirthDate { get; set; } 
        public DateTime? DeathDate { get; set; }
        public string? Biography { get; set; }
        public string? OfficialWebsite { get; set; }
    }
}
