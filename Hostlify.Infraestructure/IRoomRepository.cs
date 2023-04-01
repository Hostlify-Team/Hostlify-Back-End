namespace Hostlify.Infraestructure;

public interface IRoomRepository
{
    Task<List<Room>> getAll();
    Task<List<Room>> getRoomforManagerId(int managerId);
    Task<Room> getRoomforGuestId(int guestId);
    Task<Room> getRoombyRoomName(string roomName);
    Task<bool> postroom(Room room);
    Task<bool> updateroom(int id,Room room);
    Task<bool> deleteroom(int id);
}