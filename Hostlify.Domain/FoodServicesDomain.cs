using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public class FoodServicesDomain :  IFoodServicesDomain
{
    private IFoodServicesRepository _foodServicesRepositoryImplementation;
    private IFoodServicesDomain _foodServicesDomainImplementation;

    public Task<List<FoodServices>> getAll()
    {
        return _foodServicesRepositoryImplementation.getAll();
    }

    public Task<bool> post(FoodServices foodServices)
    {
        return _foodServicesRepositoryImplementation.post(foodServices);
    }

    public Task<FoodServices> getFoodServiceByRoomId(int RoomId)
    {
        return _foodServicesDomainImplementation.getFoodServiceByRoomId(RoomId);
    }


    public Task<bool> DeletebyRoomID(int RoomId)
    {
        return _foodServicesRepositoryImplementation.DeletebyRoomID(RoomId);
    }

    public Task<bool> Delete(int id)
    {
        return _foodServicesRepositoryImplementation.Delete(id);
    }
}