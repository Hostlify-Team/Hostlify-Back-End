using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public class CleaningServicesDomain: ICleaningServicesDomain
{
    private ICleaningServicesRepository _cleaningServicesRepository;

    public CleaningServicesDomain(ICleaningServicesRepository cleaningServicesRepository)
    {
        _cleaningServicesRepository = cleaningServicesRepository;
    }

    public async Task<List<CleaningServices>> getAll()
    {
        return await _cleaningServicesRepository.getAll();
    }

    public async Task<bool> postCleaningService(CleaningServices cleaningServices)
    {
        return await _cleaningServicesRepository.postCleaningService(cleaningServices);
    }

    public async Task<List<CleaningServices>> getCleaningServiceByRoomId(int roomId)
    {
        return await _cleaningServicesRepository.getCleaningServiceByRoomId(roomId);
    }

    public async Task<List<CleaningServices>> getCleaningServiceAttendedByRoomId(int roomId)
    {
        return await _cleaningServicesRepository.getCleaningServiceAttendedByRoomId(roomId);
    }

    public async Task<List<CleaningServices>> getCleaningServiceUnAttendedByRoomId(int roomId)
    {
        return await _cleaningServicesRepository.getCleaningServiceUnAttendedByRoomId(roomId);
    }

    public async Task<bool> deleteAllCleaningServiceByRoomId(int id)
    {
        return await _cleaningServicesRepository.deleteAllCleaningServiceByRoomId(id);
    }

    public async Task<bool> attendByid(int id)
    {
        return await _cleaningServicesRepository.attendByid(id);
    }
}