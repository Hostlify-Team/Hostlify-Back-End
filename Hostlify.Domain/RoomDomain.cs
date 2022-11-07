using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public class RoomDomain : IRoomDomain
{
    public Task<List<Room>> getAll()
    {
        throw new NotImplementedException();
    }

    public Task<Room> getRoombyId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> update(int id, Room room)
    {
        throw new NotImplementedException();
    }
}