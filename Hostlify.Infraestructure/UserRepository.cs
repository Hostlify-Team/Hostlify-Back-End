using Hostlify.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hostlify.Infraestructure;

public class UserRepository:IUserRepository
{
    
    private HostlifyDB _hostlifyDb;

    public UserRepository(HostlifyDB hostlifyDb)
    {
        _hostlifyDb = hostlifyDb;
    }
    
    public async Task<User> GetByUsername(string username)
    {
        return await _hostlifyDb.Users.SingleOrDefaultAsync(user => user.Username ==  username);
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
}