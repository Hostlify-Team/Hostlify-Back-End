namespace Hostlify.Infraestructure;

public interface ICleaningServicesRepository
{
    Task<List<CleaningServices>> getAll();
    Task<bool> postCleaningService(CleaningServices cleaningService);
    Task<List<CleaningServices>>  getCleaningServiceByRoomId(int roomid);
    Task<bool> deletebyid(int id);
}