using Hostlify.Infraestructure;

namespace Hostlify.API.Response;

public class RoomResponse : BaseResponse<Room>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public Room Body { get; set; }
}