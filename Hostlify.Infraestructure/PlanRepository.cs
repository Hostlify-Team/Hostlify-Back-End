using Hostlify.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hostlify.Infraestructure;

public class PlanRepository: IPlanRepository
{
    private HostlifyDB _hostlifyDb;

    public PlanRepository(HostlifyDB hostlifyDb)
    {
        _hostlifyDb = hostlifyDb;
    }
    public async Task<List<Plan>>  getAll()
    {
        return await _hostlifyDb.Plans.Where(plan=>plan.IsActive == true)
            .ToListAsync();
        
    }

    public async Task<bool> update(int id,Plan plan)
    {
        using (var transacction = await _hostlifyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var existingPlan = await _hostlifyDb.Plans.FindAsync(id);
                existingPlan.Name = plan.Name;
                existingPlan.Rooms = plan.Rooms;
                existingPlan.Price = plan.Price;

                _hostlifyDb.Plans.Update(existingPlan);
                await _hostlifyDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _hostlifyDb.Database.RollbackTransactionAsync();
            }
        }

        return true;

    }
    
    

}