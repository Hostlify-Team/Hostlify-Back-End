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
        return await _hostlifyDb.Users.SingleOrDefaultAsync(user => user.Id ==  id && user.IsActive==true);
    }

    public async Task<bool> Login(User user)
    {
        _hostlifyDb.Users.Add(user);
        await _hostlifyDb.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SingUp(User user)
    {
        User existingUser = new User();
        existingUser= await _hostlifyDb.Users.SingleOrDefaultAsync(user_ => user_.Email ==  user.Email && user_.IsActive==true);
        if (existingUser != null)
        {
            return false;
        }
        
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
        return true;  
    }

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
                await _hostlifyDb.Database.CommitTransactionAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _hostlifyDb.Database.RollbackTransactionAsync();
                return false;
            }
        }

       
    }

    public async Task< List<User>> GetAllUsers()
    {
        return await _hostlifyDb.Users.Where(user=>user.IsActive == true)
            .ToListAsync();
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _hostlifyDb.Users.SingleOrDefaultAsync(user => user.Email ==  email&& user.IsActive==true);
    }
}