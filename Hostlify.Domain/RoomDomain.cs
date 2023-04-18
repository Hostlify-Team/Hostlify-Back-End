using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public class RoomDomain : IRoomDomain
{
    private IRoomRepository _RoomRepository;
    //private IRoomDomain _roomDomainImplementation; ESTO ESTA MAL

    public RoomDomain(IRoomRepository RoomRepository)
    {
        _RoomRepository = RoomRepository;
    }

    public async Task<List<Room>> getAll()
    {
        return await _RoomRepository.getAll();
    }

    public async Task<List<Room>> getRoomforManagerId(int managerId)
    {
        return await _RoomRepository.getRoomforManagerId(managerId);
    }

    public async Task<Room> getRoomforGuestId(int guestId)
    {
        return await _RoomRepository.getRoomforGuestId(guestId);
    }

    public async Task<int> postroom(Room room)
    {
        return await _RoomRepository.postroom(room);
    }

    public async Task<bool> updateroom(int id, Room room)
    {
        return await _RoomRepository.updateroom(id, room);
    }

    public async Task<bool> deleteroom(int id)
    {
        return await _RoomRepository.deleteroom(id);
    }

    public async Task<Room> getRoombyRoomName(string roomName)
    {
        return await _RoomRepository.getRoombyRoomName(roomName);
    }

    public async Task<bool> evictGuest(int id)
    {
        return await _RoomRepository.evictGuest(id);
    }

    public async Task<int> registerGuest(Room room, string userName, string userEmail, string userPassword)
    {
        return await _RoomRepository.registerGuest(room, userName, userEmail, userPassword);
    }
}