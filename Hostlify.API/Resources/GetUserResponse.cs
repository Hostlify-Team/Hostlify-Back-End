namespace Hostlify.API.Resource;

public class GetUserResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Plan { get; set; }
    public string Type { get; set; }
}