using System.ComponentModel.DataAnnotations;

namespace Hostlify.API.Resource;

public class FoodServicesResource
{
    [Required]
    public int RoomID { get; set; }
    public int ManagerID { get; set; }
    public string Dish { get; set; }
}