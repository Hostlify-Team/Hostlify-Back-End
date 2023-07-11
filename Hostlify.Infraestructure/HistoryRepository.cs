using Hostlify.Infraestructure.Context;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace Hostlify.Infraestructure;

public class HistoryRepository : IHistoryRepository
{
    private HostlifyDB _hostlifyDb;

    public HistoryRepository(HostlifyDB hostlifyDb)
    {
        _hostlifyDb = hostlifyDb;
    }
    public async Task<List<History>> getAll()
    {
        return await _hostlifyDb.History.Where(history => history.IsActive == true)
            .ToListAsync();

    }



    public async Task<bool> postHistory(History history)
    {   

        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                await _hostlifyDb.History.AddAsync(history);
                await _hostlifyDb.SaveChangesAsync();
                await transacction.CommitAsync();
            }

            catch (Exception ex)
            {
                transacction.RollbackAsync();
            }
            finally
            {
                await transacction.DisposeAsync();
            }
        }
        return true;
    }


    public async Task<List<History>> getHistoryForManagerId(int managerId)                
    {
        return await _hostlifyDb.History
            .Where(history => history.IsActive == true && history.managerId==managerId)
            .ToListAsync(); 
    }

    public async Task<bool> deleteHistory(int id)
    {
        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var historyRoom = await _hostlifyDb.History.FindAsync(id);
                historyRoom.IsActive = false;
                historyRoom.DateUpdated = DateTime.Now;
                _hostlifyDb.History.Update(historyRoom);
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