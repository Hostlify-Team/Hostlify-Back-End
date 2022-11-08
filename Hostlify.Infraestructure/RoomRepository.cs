﻿using Hostlify.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hostlify.Infraestructure;

public class RoomRepository : IRoomRepository
{
    private readonly HostlifyDB _hostlifyDb;
  

    public RoomRepository(HostlifyDB hostlifyDb)
    {
        _hostlifyDb = hostlifyDb;
    }
    public async Task<List<Room>>  getAll()
    {
        return await _hostlifyDb.Rooms.Where(room=>room.IsActive == true)
           .ToListAsync();
   
    }

    public async Task<Room> getRoomforManagerId(int managerId)
    {
        return await _hostlifyDb.Rooms
            .SingleOrDefaultAsync(room => room.ManagerId == managerId); 
    }

    public async Task<Room> getRoomforGuestId(int guestId)
    {
        return await _hostlifyDb.Rooms
            .SingleOrDefaultAsync(room => room.GuestId == guestId);
    }

    public async Task<bool> postroom(Room room)
    {
        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                await _hostlifyDb.Rooms.AddAsync(room);
                await _hostlifyDb.SaveChangesAsync();
                await transacction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transacction.RollbackAsync();
            }
            finally
            {
                await transacction.DisposeAsync();
            }
        }

        return true;
    }
               

    public async Task<bool> updateroom(int id, Room room)
    {
        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var existingRoom = await _hostlifyDb.Rooms.FindAsync(id);

               existingRoom.Name = room.Name;
               existingRoom.Description = room.Description;
               existingRoom.DateUpdated = DateTime.Now;

               _hostlifyDb.Rooms.Update(existingRoom);
                await _hostlifyDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _hostlifyDb.Database.RollbackTransactionAsync();
            }
        }

        return true;
    }
    

    public async Task<bool> deleteroom(int id)
    {
        var room = await _hostlifyDb.Rooms.FindAsync(id);
        room.IsActive = false;
        room.DateUpdated = DateTime.Now;
        _hostlifyDb.Rooms.Update(room);
        await _hostlifyDb.SaveChangesAsync();
        return true;
    }
}