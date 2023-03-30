using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public class FoodServicesDomain :  IFoodServicesDomain
{

    private IFoodServicesRepository _FoodServicesRepository;
    

    public FoodServicesDomain(IFoodServicesRepository FoodServicesRepository)
    {
        _FoodServicesRepository = FoodServicesRepository;
    }


    public async Task<List<FoodServices>> getAll()
    {
        return await _FoodServicesRepository.getAll();
    }

    public async Task<bool> postfoodservice(FoodServices foodServices)
    {
        return await _FoodServicesRepository.postfoodservice(foodServices);
    }

    public async Task<List<FoodServices>> getFoodServiceByRoomId(int roomId)
    {
        return await _FoodServicesRepository.getFoodServiceByRoomId(roomId);
    }

    public async Task<bool> deletebyid(int id)
    {
        return await _FoodServicesRepository.deletebyid(id);
    }
}