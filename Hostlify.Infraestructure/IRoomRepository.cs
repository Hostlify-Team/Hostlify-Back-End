namespace Hostlify.Infraestructure;

public interface IRoomRepository
{
    Task<List<Room>> getAll();
    Task<List<Room>> getRoomforManagerId(int managerId);
    Task<Room> getRoomforGuestId(int guestId);
    Task<Room> getRoombyRoomName(string roomName);
    Task<int> postroom(Room room);
    Task<bool> updateroom(int id,Room room);
    Task<bool> deleteroom(int id);
    Task<bool> evictGuest(int id);
    Task<int> registerGuest(Room room,string userName,string userEmail,string userPassword);
}