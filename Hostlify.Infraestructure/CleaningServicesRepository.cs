using Hostlify.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hostlify.Infraestructure;

public class CleaningServicesRepository: ICleaningServicesRepository
{
    private HostlifyDB _hostlifyDb;

    public CleaningServicesRepository(HostlifyDB hostlifyDb)
    {
        _hostlifyDb = hostlifyDb;
    }


    public async Task<List<CleaningServices>> getAll()
    {
        return await _hostlifyDb.CleaningServices.Where(cleaningServices=>cleaningServices.IsActive == true)
                    .ToListAsync();
    }

    public async Task<bool> postCleaningService(CleaningServices cleaningService)
    {
        using (var transaction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                await _hostlifyDb.CleaningServices.AddAsync(cleaningService);
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

    public async Task<List<CleaningServices>> getCleaningServiceByRoomId(int roomid)
    {
        return await _hostlifyDb.CleaningServices
            .Where(cleaningService => cleaningService.roomId == roomid && cleaningService.IsActive==true).ToListAsync(); 

    }

    public async Task<bool> deletebyid(int id)
    {
        using (var transacction  = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var cleaningService = await _hostlifyDb.CleaningServices.FindAsync(id);
                cleaningService.IsActive = false;
                cleaningService.DateUpdated = DateTime.Now;
                _hostlifyDb.CleaningServices.Update(cleaningService);
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