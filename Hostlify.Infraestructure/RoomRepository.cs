using Hostlify.Infraestructure.Context;
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

    public async Task<List<Room>> getRoomforManagerId(int managerId)
    {
        return await _hostlifyDb.Rooms
            .Where(room => room.ManagerId == managerId && room.IsActive==true).ToListAsync(); 
    }

    public async Task<Room> getRoomforGuestId(int guestId)
    {
        return await _hostlifyDb.Rooms
            .SingleOrDefaultAsync(room => room.GuestId == guestId && room.IsActive==true);
    }

    public async Task<Room> getRoombyRoomName(string roomName)
    {
        return await _hostlifyDb.Rooms
            .SingleOrDefaultAsync(room => room.RoomName == roomName && room.IsActive==true);    }

    public async Task<int> postroom(Room room)
    {
        using (var transaction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                await _hostlifyDb.Rooms.AddAsync(room);
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

        Room roomResponse = new Room();
        roomResponse=await _hostlifyDb.Rooms.SingleOrDefaultAsync(room_ => room_.RoomName ==  room.RoomName && room_.IsActive==true && room_.ManagerId==room.ManagerId);

        return roomResponse.Id;
    }
               

    public async Task<bool> updateroom(int id, Room room)
    {
        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var existingRoom = await _hostlifyDb.Rooms.FindAsync(id);
                //Console.WriteLine("ENCONTRE DATO: "+existingRoom.Name);
                
               existingRoom.RoomName = room.RoomName;
               existingRoom.Description = room.Description;
               existingRoom.GuestId = room.GuestId;
               existingRoom.ManagerId = room.ManagerId;
               existingRoom.InitialDate = room.InitialDate;
               existingRoom.EndDate = room.EndDate;
               existingRoom.Status = room.Status;
               existingRoom.Price = room.Price;
               existingRoom.Emergency = room.Emergency;
               existingRoom.ServicePending = room.ServicePending;
               existingRoom.DateUpdated = DateTime.Now;

               _hostlifyDb.Rooms.Update(existingRoom);
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
    

    public async Task<bool> deleteroom(int id)
    {
        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var room = await _hostlifyDb.Rooms.FindAsync(id);
                room.IsActive = false;
                room.DateUpdated = DateTime.Now;
                _hostlifyDb.Rooms.Update(room);
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

    public async Task<bool> evictGuest(int id)
    {
        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var existingRoom = await _hostlifyDb.Rooms.FindAsync(id);
                var existingUser = await _hostlifyDb.Users.FindAsync(existingRoom.GuestId);

                existingUser.IsActive = false;
                existingRoom.GuestId = null;
                existingRoom.InitialDate = null;
                existingRoom.EndDate = null;
                existingRoom.Status = true;
                existingRoom.Price = null;
                existingRoom.Emergency = false;
                existingRoom.ServicePending = false;
                existingRoom.DateUpdated = DateTime.Now;
                
                _hostlifyDb.Users.Update(existingUser);
                _hostlifyDb.Rooms.Update(existingRoom);
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

    public async Task<int> registerGuest(Room room,string userName,string userEmail,string userPassword)
    {
        User existingUser_ = new User();
        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {

                var existingRoom = await _hostlifyDb.Rooms.FindAsync(room.Id);
                existingUser_= await _hostlifyDb.Users.SingleOrDefaultAsync(user_ => user_.Email ==  userEmail && user_.IsActive==true);
                existingRoom.GuestId = existingUser_.Id;
                existingRoom.InitialDate = room.InitialDate;    
                existingRoom.EndDate = room.EndDate;
                existingRoom.Status = false;
                existingRoom.Price = room.Price;
                existingRoom.Emergency = false;
                existingRoom.ServicePending = false;
                existingRoom.DateUpdated = DateTime.Now;

                History history = new History();
                history.roomName = existingRoom.RoomName;
                history.managerId = existingRoom.ManagerId;
                history.guestName = userName;
                history.initialDate = room.InitialDate;
                history.endDate = room.EndDate;
                history.price = room.Price.GetValueOrDefault();
                history.description = existingRoom.Description;



                _hostlifyDb.Rooms.Update(existingRoom);
                _hostlifyDb.History.Update(history);
                await _hostlifyDb.SaveChangesAsync();
                await _hostlifyDb.Database.CommitTransactionAsync();
                return existingUser_.Id;
            }
            catch (Exception ex)
            {
                await _hostlifyDb.Database.RollbackTransactionAsync();
                return 0;
            }
        }
    }
}