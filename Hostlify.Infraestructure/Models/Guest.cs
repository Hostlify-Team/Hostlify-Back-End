namespace Hostlify.Infraestructure;

public class Guest : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Lastname { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }

}