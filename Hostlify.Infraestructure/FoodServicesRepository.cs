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
        var foodService = _hostlifyDb.FoodServices.FindAsync(id);
        foodService.IsCanceled = true;
        _hostlifyDb.FoodServices.Update(foodService);
        await _hostlifyDb.SaveChangesAsync();
        return true;
    }
}