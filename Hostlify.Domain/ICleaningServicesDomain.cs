using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface ICleaningServicesDomain
{
    Task<List<CleaningServices>> getAll();
    Task<bool> postCleaningService(CleaningServices cleaningServices);
    Task<List<CleaningServices>>  getCleaningServiceByRoomId(int roomId);
    Task<List<CleaningServices>>  getCleaningServiceAttendedByRoomId(int roomId);
    Task<List<CleaningServices>>  getCleaningServiceUnAttendedByRoomId(int roomId);
    Task<bool> deleteAllCleaningServiceByRoomId(int id);
    Task<bool> attendByid(int id);
}