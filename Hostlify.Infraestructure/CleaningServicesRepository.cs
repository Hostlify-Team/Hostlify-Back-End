﻿using Hostlify.Infraestructure.Context;
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
        return await _hostlifyDb.CleaningServices.Where(cleaningServices=>cleaningServices.IsActive == true && cleaningServices.attended==false)
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

    public async Task<List<CleaningServices>> getCleaningServiceByRoomId(int roomid)
    {
        return await _hostlifyDb.CleaningServices
            .Where(cleaningService => cleaningService.roomId == roomid && cleaningService.IsActive==true).ToListAsync(); 

    }

    public async Task<List<CleaningServices>> getCleaningServiceAttendedByRoomId(int roomid)
    {
        return await _hostlifyDb.CleaningServices
            .Where(cleaningService => cleaningService.roomId == roomid && cleaningService.IsActive==true&& cleaningService.attended==true).ToListAsync(); 
    }

    public async Task<List<CleaningServices>> getCleaningServiceUnAttendedByRoomId(int roomid)
    {
        return await _hostlifyDb.CleaningServices
            .Where(cleaningService => cleaningService.roomId == roomid && cleaningService.IsActive==true&& cleaningService.attended==false).ToListAsync(); 
    }

    public async Task<bool> deleteAllCleaningServiceByRoomId(int id)
    {
        using (var transacction  = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var cleaningServices = await _hostlifyDb.CleaningServices
                    .Where(cs => cs.roomId == id && cs.IsActive==true)
                    .ToListAsync();
            
                foreach (var cleaningService in cleaningServices)
                {
                    cleaningService.IsActive = false;
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
                var cleaningService = await _hostlifyDb.CleaningServices.FindAsync(id);
                cleaningService!.attended = true;
                cleaningService.DateUpdated = DateTime.Now;
                _hostlifyDb.CleaningServices.Update(cleaningService);
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