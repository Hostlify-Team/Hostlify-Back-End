namespace Hostlify.Infraestructure;

public class History : BaseModel
{
    public int id { get; set; }

    public int roomName { get; set; }
    public string managerId { get; set; }
    public int guestId { get; set; }

    public string guestName { get; set; }

    public string guestEmail { get; set; }

    public int initialDate { get; set; }

    public int endDate { get; set; }

    public int price { get; set; }

    public string description { get; set; }
}