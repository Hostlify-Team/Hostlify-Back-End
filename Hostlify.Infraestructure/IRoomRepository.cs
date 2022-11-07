namespace Hostlify.Infraestructure;

public interface IRoomRepository
{
    Task<List<Room>> getAll();
    Task<Room> getRoombyId(int id);
    Task<bool> update(int id,Room room);
    Task<bool> post(Room room);
}