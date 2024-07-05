namespace AudioStreaming.Domain;

public class User
{
    public int Id { get; set; }
    public Password Password { get; set; }
    public Email Email { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public User()
    {
    }

    public User(string email, string password, string role)
    {
        Email = new Email(email);
        Password = new Password(password);
        Role.TryParse(role, out Role parsedRole);
        Role = parsedRole;
    }
}
