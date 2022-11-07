namespace Hostlify.Infraestructure;

public class Room : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Guest GuestId { get; set; }
    public DateTime Initialdate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Status { get; set; }
    public bool GuestStayComplete { get; set; }
    public int Price { get; set; }

    public string Description { get; set; }
    public bool Emergency { get; set; }
    public bool ServicePending { get; set; }
}