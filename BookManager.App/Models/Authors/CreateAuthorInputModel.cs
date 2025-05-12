namespace BookManager.App.Models.Authors
{
    public class CreateAuthorInputModel
    {
        public CreateAuthorInputModel(string name, string? nationality, DateTime? birthDate, DateTime? deathDate, string? biography, string? officialWebsite)
        {
            Name = name;
            Nationality = nationality;
            BirthDate = birthDate;
            DeathDate = deathDate;
            Biography = biography;
            OfficialWebsite = officialWebsite;
        }

        public string Name { get; set; }
        public string? Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Biography { get; set; }
        public string? OfficialWebsite { get; set; }
    }
}
