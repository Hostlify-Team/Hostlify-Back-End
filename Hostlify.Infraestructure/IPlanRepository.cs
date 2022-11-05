namespace Hostlify.Infraestructure;

public interface IPlanRepository
{
    Task<List<Plan>> getAll();

    Task<bool> update(int id,Plan plan);

    Task<bool> post(Plan plan);
}