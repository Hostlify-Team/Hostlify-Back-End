using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface ICleaningServicesDomain
{
    Task<List<CleaningServices>> getAll();
    Task<bool> postCleaningService(CleaningServices cleaningServices);
    Task<List<CleaningServices>>  getCleaningServiceByRoomId(int roomId);
    Task<List<CleaningServices>>  getCleaningServiceAttendedByRoomId(int roomId);
    Task<bool> deletebyid(int id);
    Task<bool> attendByid(int id);
}