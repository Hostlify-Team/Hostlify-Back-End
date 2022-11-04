using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface IPlanDomain
{
    Task<List<Plan>> getAll();
    Plan gePlanById(int id);
    Boolean createPlan(string name,int rooms,int price);
}