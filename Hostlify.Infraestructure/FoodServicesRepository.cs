using Hostlify.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hostlify.Infraestructure;

public class FoodServicesRepository : IFoodServicesRepository
{
    private HostlifyDB _hostlifyDb;

    public FoodServicesRepository(HostlifyDB hostlifyDb)
    {
        _hostlifyDb = hostlifyDb;
    }


    public Task<List<FoodServices>> getAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> post(FoodServices foodServices)
    {
        throw new NotImplementedException();
    }

    public FoodServices getFoodServiceByRoomId(int RoomId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletebyRoomID(int RoomId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
}