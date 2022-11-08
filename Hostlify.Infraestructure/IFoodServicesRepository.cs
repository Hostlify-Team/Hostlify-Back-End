namespace Hostlify.Infraestructure;

public interface IFoodServicesRepository
{
    Task<List<FoodServices>> getAll();
    Task<bool> post(FoodServices foodServices);
    FoodServices  getFoodServiceByRoomId(int id);
    Task<bool>  deleteFoodServiceByRoomId(int id);
    Task<bool> deleteFoodServiceById(int id);
}