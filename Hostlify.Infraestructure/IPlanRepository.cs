namespace Hostlify.Infraestructure;

public interface IPlanRepository
{
    Task<List<Plan>> getAll();
    Plan gePlanById(int id);
    Boolean createPlan(string name,int rooms,int price);
}