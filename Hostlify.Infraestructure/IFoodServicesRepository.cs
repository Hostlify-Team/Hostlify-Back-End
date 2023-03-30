namespace Hostlify.Infraestructure;

public interface IFoodServicesRepository
{
    Task<List<FoodServices>> getAll();
    Task<bool> postfoodservice(FoodServices foodServices);
    Task<List<FoodServices>>  getFoodServiceByRoomId(int roomid);

    Task<bool> deletebyid(int id);
}