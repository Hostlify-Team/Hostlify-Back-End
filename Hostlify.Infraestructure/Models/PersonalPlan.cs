namespace Hostlify.Infraestructure;

public class PersonalPlan:BaseModel
{
    public int id { get; set; }
    public int managerId { get; set; }
    public int roomsLimit { get; set; }
}