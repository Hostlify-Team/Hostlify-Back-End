namespace Hostlify.Infraestructure;

public interface ICleaningServicesRepository
{
    Task<List<CleaningServices>> getAll();
    Task<bool> postCleaningService(CleaningServices cleaningService);
    Task<List<CleaningServices>>  getCleaningServiceByRoomId(int roomid);
    Task<List<CleaningServices>>  getCleaningServiceAttendedByRoomId(int roomid);
    Task<List<CleaningServices>>  getCleaningServiceUnAttendedByRoomId(int roomid);
    Task<bool> deleteAllCleaningServiceByRoomId(int id);
    Task<bool> attendByid(int id);
}