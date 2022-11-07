using Hostlify.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hostlify.Infraestructure;

public class RoomRepository : IRoomRepository
{
    private HostlifyDB _hostlifyDb;
    
    public RoomRepository(HostlifyDB hostlifyDb)
    {
        _hostlifyDb = hostlifyDb;
    }
    public async Task<List<Room>>  getAll()
    {
        //return await _hostlifyDb.Room.Where(room=>room.IsActive == true)
        //   .ToListAsync();
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

    public Task<bool> post(Room room)
    {
        throw new NotImplementedException();
    }
}