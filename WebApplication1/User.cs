using System.Drawing;

namespace WebApplication1;

public class User
{

    public User(
        int id,
        string name,
        string login,
        string password
       )
    {
        Id = id;
        Name = name;
        Login = login;
        Password = password;
        
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    
}