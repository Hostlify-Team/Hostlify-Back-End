using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public class RoomDomain : IRoomDomain
{
    private IRoomRepository _RoomRepository;

    public RoomDomain(IRoomRepository RoomRepository)
    {
        _RoomRepository = RoomRepository;
    }

    public async Task<List<Room>> getAll()
    {
        return await _RoomRepository.getAll();
    }

    public async Task<bool> post(Room room)
    {
        return await _RoomRepository.post(room);
    }

    public async Task<Room> getRoombyId(int id)
    {
        return await _RoomRepository.getRoombyId(id);
    }

    public async Task<bool> update(int id, Room room)
    {
        return await _RoomRepository.update(id, room);
    }
}