namespace Hostlify.Infraestructure;

public class FoodServices:BaseModel
{
    public int Id { get; set; }
    public int RoomID { get; set; }
    public int ManagerID { get; set; }
    public string Dish { get; set; }
    public int DishQuantity { get; set; }
    public string Drink { get; set; }
    public int DrinkQuantity { get; set; }
    public string Cream { get; set; }
    public int CreamQuantity { get; set; }
    public string? Instruction { get; set; }
}