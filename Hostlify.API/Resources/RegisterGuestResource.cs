namespace Hostlify.API.Resource;

public class RegisterGuestResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string InitialDate { get; set; }
    public string EndDate { get; set; }
    public int Price { get; set; }
}