namespace Hostlify.Infraestructure;

public class Room : BaseModel
{
    public int Id { get; set; }
    public string RoomName { get; set; }
    public int? GuestId { get; set; }
    public int ManagerId { get; set; }
    public string? InitialDate { get; set; }
    public string? EndDate { get; set; }
    public bool Status { get; set; }
    public int? Price { get; set; }
    public string? Description { get; set; }
    public bool Emergency { get; set; }
    public bool ServicePending { get; set; }

}
