namespace Hostlify.Infraestructure;

public class CleaningServices: BaseModel
{
    public int id { get; set; }
    public int roomId { get; set; }
    public string? instruction { get; set; }
}