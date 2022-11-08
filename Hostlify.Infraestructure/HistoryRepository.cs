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

    public async Task<bool> update(int id, History history)
    {
        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var existingHistory = await _hostlifyDb.History.FindAsync(id);
                existingHistory.roomName = history.roomName;
                existingHistory.managerId = history.managerId;
                existingHistory.guestName = history.guestName;
                existingHistory.initialDate = history.initialDate;
                existingHistory.endDate = history.endDate;
                existingHistory.price = history.price;
                existingHistory.description = history.description;

                _hostlifyDb.History.Update(existingHistory);
                _hostlifyDb.SaveChangesAsync();
                _hostlifyDb.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _hostlifyDb.Database.RollbackTransactionAsync();
            }
        }

        return true;

    }

    public async Task<bool> post(History history)
    {

        using (var transaction = _hostlifyDb.Database.BeginTransactionAsync())//Empiezo la transaccion eñ using es para abrir y cerrar coneccion automaticamente
        {
            try
            {
                _hostlifyDb.History.AddAsync(history); //Agregado a nivel de memoria Y CON AddAsync
                _hostlifyDb.SaveChanges(); //Agregado a la base de datos y con SaveAsync
                _hostlifyDb.Database.CommitTransactionAsync(); //termino la transaccion

            }
            catch (Exception ex)
            {
                _hostlifyDb.Database.RollbackTransactionAsync();
            }
            finally
            {
                _hostlifyDb.DisposeAsync();
            }
        }
        return true;
    }

    public History getHistoryById(int id)
    {
        throw new NotImplementedException();
    }

    public bool createHistory(int roomName, string managerId, int guestId, string guestName, string guestEmail,
        DateTime initialDate, DateTime endDate, int price, string description)
    {
        throw new NotImplementedException();
    }

    public async Task<History> getHistoryForManager(int id)
    {
        return await _hostlifyDb.History
            .SingleOrDefaultAsync(history => history.managerId == id); 
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