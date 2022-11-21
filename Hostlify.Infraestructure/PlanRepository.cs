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

    public async Task<bool> post(Plan plan)
    {

        using (var transaction=_hostlifyDb.Database.BeginTransactionAsync())//Empiezo la transaccion eñ using es para abrir y cerrar coneccion automaticamente
        {
            try
            {
                _hostlifyDb.Plans.AddAsync(plan); //Agregado a nivel de memoria Y CON AddAsync
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



}