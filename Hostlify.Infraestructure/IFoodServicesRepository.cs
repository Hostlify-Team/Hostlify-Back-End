namespace Hostlify.Infraestructure;

public interface IFoodServicesRepository
{
    Task<List<FoodServices>> getAll();
    Plan geFoodServicesById(int id);
    Boolean createFoodServices(string dish, int dishQuantity, string drink, int drinkQuantity, string cream, int creamQuantity, string instruction);
}