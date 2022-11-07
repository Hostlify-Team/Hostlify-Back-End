using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface IFoodServicesDomain
{
    Task<List<FoodServices>> getAll();
    Task<bool> post(FoodServices foodServices);
    Task<FoodServices> getFoodServiceByRoomId(int RoomId);
    Task<bool> DeletebyRoomID(int RoomId);
    Task<bool> Delete(int id);
}