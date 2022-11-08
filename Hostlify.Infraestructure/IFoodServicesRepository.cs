namespace Hostlify.Infraestructure;

public interface IFoodServicesRepository
{
    Task<List<FoodServices>> getAll();
    Task<bool> postfoodservice(FoodServices foodServices);
    Task<FoodServices>  getFoodServiceByRoomId(int roomId);
    
    Task<bool> deletebyRoomID(int roomId);
    
    Task<bool> deletebyid(int id);
}