namespace Hostlify.Infraestructure;

public interface IFoodServicesRepository
{
    Task<List<FoodServices>> getAll();
    Task<bool> post(FoodServices foodServices);
    FoodServices  getFoodServiceByRoomId(int RoomId);
    Task<bool> DeletebyRoomID(int RoomId);
    Task<bool> Delete(int id);
}