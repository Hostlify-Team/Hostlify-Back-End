using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public class RoomDomain : IRoomDomain
{
    private IRoomRepository _RoomRepository;
    private IRoomDomain _roomDomainImplementation;

    public RoomDomain(IRoomRepository RoomRepository)
    {
        _RoomRepository = RoomRepository;
    }

    public async Task<List<Room>> getAll()
    {
        return await _RoomRepository.getAll();
    }

    public async Task<Room> getRoomforManagerId(int managerId)
    {
        return await _roomDomainImplementation.getRoomforManagerId(managerId);
    }

    public async Task<Room> getRoomforGuestId(int guestId)
    {
        return await _roomDomainImplementation.getRoomforGuestId(guestId);
    }

    public async Task<bool> postroom(Room room)
    {
        return await _roomDomainImplementation.postroom(room);
    }

    public async Task<bool> updateroom(int id, Room room)
    {
        return await _roomDomainImplementation.updateroom(id, room);
    }

    public async Task<bool> deleteroom(int id)
    {
        return await _roomDomainImplementation.deleteroom(id);
    }
}