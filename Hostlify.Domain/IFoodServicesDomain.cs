using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface IFoodServicesDomain
{
    Task<List<FoodServices>> getAll();
    Task<bool> postfoodservice(FoodServices foodServices);
    Task<List<FoodServices>>  getFoodServiceByRoomId(int roomId);
    Task<List<FoodServices>>  getFoodServiceAttendedByRoomId(int roomId);
    Task<List<FoodServices>>  getFoodServiceUnAttendedByRoomId(int roomId);
    Task<bool> deleteAllFoodServicesByRoomId(int id);
    Task<bool> attendByid(int id);
}