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

    public async Task<bool> deletebyid(int id)
    {
        return await _cleaningServicesRepository.deletebyid(id);
    }
}