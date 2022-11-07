using Hostlify.Infraestructure.Context;

namespace Hostlify.Infraestructure;

public class RoomRepository : IRoomRepository
{
    private HostlifyDB _hostlifyDb;
    
    public RoomRepository(HostlifyDB hostlifyDb)
    {
        _hostlifyDb = hostlifyDb;
    }
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