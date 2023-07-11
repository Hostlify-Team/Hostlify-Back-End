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

    public async Task<int> GetRoomsLimitByUserId(int id)
    {
        PersonalPlan personalPlan = new PersonalPlan();
        User existingUser = new User();
        existingUser= await _hostlifyDb.Users.SingleOrDefaultAsync(user_ => user_.Id ==  id && user_.IsActive==true);
         if (existingUser != null)
         {
             personalPlan= await _hostlifyDb.PersonalPlans.SingleOrDefaultAsync(personalPlan_ =>
                 personalPlan_.managerId == id && personalPlan_.IsActive == true);
             if (personalPlan != null)
             {
                 return personalPlan.roomsLimit;
             }
             else
             {
                 return 0;
 
             }
         }
         else
         {
             return 0;
         }

    }

    public async Task<bool> UpdateRoomsLimitByUserId(int id, string actualPlan, string changedPlan,int newCustomRoomLimit)
    {
        using (var transaction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            if (actualPlan == "Custom" && changedPlan=="Custom")
            {
                Console.WriteLine(actualPlan+changedPlan);
                try
                {
                    var existingPlan = await _hostlifyDb.PersonalPlans
                        .FirstOrDefaultAsync(plan => plan.IsActive && plan.managerId == id);
            
                    if (existingPlan != null)
                    {
                        existingPlan.roomsLimit = newCustomRoomLimit;
                        _hostlifyDb.PersonalPlans.Update(existingPlan);
                        await _hostlifyDb.SaveChangesAsync();
                        await _hostlifyDb.Database.CommitTransactionAsync();
                        return true; 
                    }
                    transaction.Rollback(); 
                    return false; 
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Deshacer la transacción en caso de excepción
                    // Manejo de la excepción (por ejemplo, registro de errores)
                    throw;
                }
            }
            
            if (actualPlan == "Custom" && changedPlan != "Custom")
            {
                Console.WriteLine(actualPlan+changedPlan);
                var existingPlan = await _hostlifyDb.PersonalPlans
                    .FirstOrDefaultAsync(plan => plan.IsActive && plan.managerId == id);
                var existingUser = await _hostlifyDb.Users.FindAsync(id);
                
                if (existingPlan != null && existingUser != null)
                {
                    existingPlan.IsActive = false;
                    _hostlifyDb.PersonalPlans.Update(existingPlan);

                    existingUser.Plan = changedPlan;
                    _hostlifyDb.Users.Update(existingUser);
                    
                    await _hostlifyDb.SaveChangesAsync();
                    await _hostlifyDb.Database.CommitTransactionAsync();
                    return true;
                }
                transaction.Rollback(); 
                return false;

            }

            if (actualPlan != "Custom" && changedPlan == "Custom")
            {
                try
                {
                    Console.WriteLine(actualPlan+changedPlan);
                    var existingUser = await _hostlifyDb.Users.FindAsync(id);
                    
                    var existingPlan = await _hostlifyDb.PersonalPlans
                        .FirstOrDefaultAsync(plan => plan.IsActive && plan.managerId == id);
                    if (existingPlan == null)
                    {
                        PersonalPlan personalPlan = new PersonalPlan();
                        personalPlan.managerId = existingUser.Id;
                        personalPlan.roomsLimit = newCustomRoomLimit;
                    
                        if (existingUser != null)
                        {
                            existingUser.Plan = changedPlan;
                            _hostlifyDb.Users.Update(existingUser);


                            await _hostlifyDb.PersonalPlans.AddAsync(personalPlan);
                            await _hostlifyDb.SaveChangesAsync();
                            await _hostlifyDb.Database.CommitTransactionAsync();

                            return true; 
                        }
                    }
                    transaction.Rollback();
                    return false; 
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); 
                    throw;
                }
            }

            if (actualPlan != "Custom" && changedPlan != "Custom")
            {
                Console.WriteLine(actualPlan+changedPlan);
                try
                {
                    var existingUser = await _hostlifyDb.Users.FindAsync(id);
                    if (existingUser != null)
                    {
                        existingUser.Plan = changedPlan;
                        _hostlifyDb.Users.Update(existingUser);
                        await _hostlifyDb.SaveChangesAsync();
                        await _hostlifyDb.Database.CommitTransactionAsync();
                        return true; 
                    }
                    transaction.Rollback();
                    return false; 
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); 
                    throw;
                }
            }

            return false;

        }
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
                if (existingUser.Type == "manager" && existingUser.Plan == "Custom")
                {
                    PersonalPlan existingPersonalPlan = new PersonalPlan();
                    existingPersonalPlan= await _hostlifyDb.PersonalPlans.SingleOrDefaultAsync(personalPlan_ =>
                        personalPlan_.managerId == id && personalPlan_.IsActive == true);
                    existingPersonalPlan.IsActive = false;
                    existingPersonalPlan.DateUpdated = DateTime.Now;
                    _hostlifyDb.PersonalPlans.Update(existingPersonalPlan);
                }
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

    public async Task<bool> PostPersonalPlan(string email, int roomsLimit)
    {
        User existingUser = new User();
        PersonalPlan personalPlan = new PersonalPlan();
        existingUser=await _hostlifyDb.Users.SingleOrDefaultAsync(user => user.Email ==  email&& user.IsActive==true);
        personalPlan.managerId = existingUser.Id;
        personalPlan.roomsLimit = roomsLimit;

        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                await _hostlifyDb.PersonalPlans.AddAsync(personalPlan);
                await _hostlifyDb.SaveChangesAsync();
                await transacction.CommitAsync();
                return true;  
            }
            catch (Exception ex)
            {
                await transacction.RollbackAsync();
                return false;  
            }
            finally
            {
                await transacction.DisposeAsync();
            }
        }
    }
}