namespace Hostlify.Infraestructure;

public interface IFoodServicesRepository
{
    Task<List<FoodServices>> getAll();
    Task<bool> postfoodservice(FoodServices foodServices);
    Task<FoodServices>  getFoodServiceByRoomId(int roomid);
    
    Task<bool> deletebyroomid(int roomid);
    
    Task<bool> deletebyid(int id);
}