using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public class PlanDomain : IPlanDomain
{
    private IPlanRepository _PlanRepository;

    public PlanDomain(IPlanRepository PlanRepository)
    {
        _PlanRepository = PlanRepository;
    }

    public async Task<bool> post(Plan plan)
    {
        return await _PlanRepository.post(plan);
    }

    public async Task<List<Plan>> getAll()
    {
        return await _PlanRepository.getAll();
    }

    public async Task<bool> update(int id,Plan plan)
    {
        return await _PlanRepository.update(id, plan);
    }
}