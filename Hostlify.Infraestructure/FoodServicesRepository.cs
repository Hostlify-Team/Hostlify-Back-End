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


    public async Task<List<FoodServices>> getAll()
    {
        return await _hostlifyDb.FoodServices.ToListAsync();
    }

    public async Task<bool> post(FoodServices foodServices)
    {
        using (var transaction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                await _hostlifyDb.FoodServices.AddAsync(foodServices);
                await _hostlifyDb.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                transaction.RollbackAsync();
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }

        return true;
    }

    public FoodServices getFoodServiceByRoomId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> deleteFoodServiceByRoomId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> deleteFoodServiceById(int id)
    {
        throw new NotImplementedException();
    }
}