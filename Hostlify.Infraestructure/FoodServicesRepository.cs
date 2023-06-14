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
        return await _hostlifyDb.FoodServices.Where(foodServices=>foodServices.IsActive == true && foodServices.attended==false)
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
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return false;
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }
    }

    public async Task<List<FoodServices>> getFoodServiceUnAttendedByRoomId(int roomid)
    {
        return await _hostlifyDb.FoodServices
            .Where(foodService => foodService.roomId == roomid && foodService.IsActive==true && foodService.attended==false).ToListAsync(); 
    }
    
    public async Task<List<FoodServices>> getFoodServiceByRoomId(int roomid)
    {
        return await _hostlifyDb.FoodServices
            .Where(foodService => foodService.roomId == roomid && foodService.IsActive==true).ToListAsync(); 
    }

    public async Task<List<FoodServices>> getFoodServiceAttendedByRoomId(int roomid)
    {
        return await _hostlifyDb.FoodServices
            .Where(foodService => foodService.roomId == roomid && foodService.IsActive==true && foodService.attended==true).ToListAsync(); 
    }


    public async Task<bool> deleteAllFoodServicesByRoomId(int id)
    {
        using (var transacction  = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var foodServices = await _hostlifyDb.FoodServices.Where(fs => fs.roomId == id && fs.IsActive==true).ToListAsync();
            
                foreach (var foodService in foodServices)
                {
                    foodService.IsActive = false;
                }
            
                await _hostlifyDb.SaveChangesAsync();
                await _hostlifyDb.Database.CommitTransactionAsync();
            
                return true;
            }
            catch (Exception ex)
            {
                await _hostlifyDb.Database.RollbackTransactionAsync();
            }
        }

        return false;
    }

    public async Task<bool> attendByid(int id)
    {
        using (var transacction  = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var foodService = await _hostlifyDb.FoodServices.FindAsync(id);
                foodService!.attended = true;
                foodService.DateUpdated = DateTime.Now;
                _hostlifyDb.FoodServices.Update(foodService);
                await _hostlifyDb.SaveChangesAsync();
                await _hostlifyDb.Database.CommitTransactionAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _hostlifyDb.Database.RollbackTransactionAsync();
            }
        }

        return false;
    }
}