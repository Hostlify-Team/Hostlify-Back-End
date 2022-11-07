using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface IRoomDomain
{
    Task<List<Room>> getAll();
    Task<Room> getRoombyId(int id);
    Task<bool> update(int id,Room room);
}