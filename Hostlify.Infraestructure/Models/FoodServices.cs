namespace Hostlify.Infraestructure;

public class FoodServices:BaseModel
{
    public int id { get; set; }
    public int roomId { get; set; }
    public string dish { get; set; }
    public int dishQuantity { get; set; }
    public string drink { get; set; }
    public int drinkQuantity { get; set; }
    public string cream { get; set; }
    public int creamQuantity { get; set; }
    public string? instruction { get; set; }
}