namespace BookManager.App.Models.Users
{
    public class CreateUserInputModel
    {
        public CreateUserInputModel(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}
