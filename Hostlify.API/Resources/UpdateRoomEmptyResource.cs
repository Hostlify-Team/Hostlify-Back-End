namespace Hostlify.API.Resource;

public class UpdateRoomEmptyResource
{
    public string RoomName { get; set; }
    public int ManagerId { get; set; }
    public string Description { get; set; }
    public Boolean Status { get; set; }
}