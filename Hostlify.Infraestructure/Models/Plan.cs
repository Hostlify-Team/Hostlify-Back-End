namespace Hostlify.Infraestructure;

public class Plan:BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Rooms { get; set; }
    public int Price { get; set; }
}