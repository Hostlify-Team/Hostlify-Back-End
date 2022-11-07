using Hostlify.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hostlify.Infraestructure;

public class FoodServicesRepository : IPlanRepository
{
    private HostlifyDB _hostlifyDb;

    public PlanRepository(HostlifyDB hostlifyDb)
    {
        _hostlifyDb = hostlifyDb;
    }
    public async Task<List<Plan>> getAll()
    {
        return _hostlifyDb.Plans.Where(plan => plan.IsActive == true)
            .ToList();//ESTO ES LINKQ

    }

    public Plan gePlanById(int id)
    {
        return _hostlifyDb.Plans.Find(id);
    }

    public bool createPlan(string name, int rooms, int price)
    {
        Plan plan = new Plan();
        plan.Name = name;
        plan.Rooms = rooms;
        plan.Price = price;

        _hostlifyDb.Plans.Add(plan);
        return true;
    }
}