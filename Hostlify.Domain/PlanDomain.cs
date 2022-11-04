using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public class PlanDomain : IPlanDomain
{
    private IPlanRepository _PlanRepository;

    public PlanDomain(IPlanRepository PlanRepository)
    {
        _PlanRepository = PlanRepository;
    }

    public async Task<List<Plan>> getAll()
    {
        return await _PlanRepository.getAll();
    }

    public Plan gePlanById(int id)
    {
        return _PlanRepository.gePlanById(id);
    }

    public bool createPlan(string name, int rooms, int price)
    {
        throw new NotImplementedException();
    }
}