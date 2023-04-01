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
        return await _hostlifyDb.FoodServices.Where(foodServices=>foodServices.IsActive == true)
            .ToListAsync();
    }

    public async Task<bool> postfoodservice(FoodServices foodServices)
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

    public async Task<List<FoodServices>> getFoodServiceByRoomId(int roomid)
    {
        return await _hostlifyDb.FoodServices
            .Where(foodService => foodService.roomId == roomid && foodService.IsActive==true).ToListAsync(); 
    }
    

    public async Task<bool> deletebyid(int id)
    {
        using (var transacction  = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var foodService = await _hostlifyDb.FoodServices.FindAsync(id);
                foodService.IsActive = false;
                foodService.DateUpdated = DateTime.Now;
                _hostlifyDb.FoodServices.Update(foodService);
                await _hostlifyDb.SaveChangesAsync();
                _hostlifyDb.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _hostlifyDb.Database.RollbackTransactionAsync();
            }
        }

        return true;
    }
 
}