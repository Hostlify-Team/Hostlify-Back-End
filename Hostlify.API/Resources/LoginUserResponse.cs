namespace Hostlify.API.Resource;

public class LoginUserResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Plan { get; set; }
    public string Type { get; set; } 
    public string Jwt { get; set; }
}