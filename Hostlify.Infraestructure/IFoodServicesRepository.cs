namespace Hostlify.Infraestructure;

public interface IFoodServicesRepository
{
    Task<List<FoodServices>> getAll();
    Task<bool> postfoodservice(FoodServices foodServices);
    Task<List<FoodServices>>  getFoodServiceByRoomId(int roomid);
    Task<List<FoodServices>>  getFoodServiceAttendedByRoomId(int roomid);
    Task<List<FoodServices>>  getFoodServiceUnAttendedByRoomId(int roomid);

    Task<bool> deleteAllFoodServicesByRoomId(int id);
    
    Task<bool> attendByid(int id);
}