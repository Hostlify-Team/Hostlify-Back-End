using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface IRoomDomain
{
    Task<List<Room>> getAll();
    Task<Room> getRoomforManagerId(int managerId);
    Task<Room> getRoomforGuestId(int guestId);
    Task<bool> postroom(Room room);
    Task<bool> updateroom(int id,Room room);
    Task<bool> deleteroom(int id);
}