using Hostlify.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hostlify.Infraestructure;

public class UserRepository:IUserRepository
{
    
    private readonly HostlifyDB _hostlifyDb;

    public UserRepository(HostlifyDB hostlifyDb)
    {
        _hostlifyDb = hostlifyDb;
    }
    

    public async Task<User> GetByUserId(int id)
    {
        return await _hostlifyDb.Users.SingleOrDefaultAsync(user => user.Id ==  id);
    }

    public async Task<bool> Login(User user)
    {
        _hostlifyDb.Users.Add(user);
        await _hostlifyDb.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SingUp(User user)
    {
        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                await _hostlifyDb.Users.AddAsync(user);
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
        return true;    }

    public async Task<bool> DeleteUser(int id)
    {
        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var existingUser = await _hostlifyDb.Users.FindAsync(id);

                existingUser.IsActive = false;
                existingUser.DateUpdated = DateTime.Now;

                _hostlifyDb.Users.Update(existingUser);
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

    public async Task< List<User>> GetAllUsers()
    {
        return await _hostlifyDb.Users.Where(user=>user.IsActive == true)
            .ToListAsync();
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _hostlifyDb.Users.SingleOrDefaultAsync(user => user.Email ==  email);
    }
}