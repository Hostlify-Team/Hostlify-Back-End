using System.ComponentModel.DataAnnotations;

namespace Hostlify.API.Resource;

public class FoodServicesResource
{
    [Required]
    public int RoomID { get; set; }
    public int ManagerID { get; set; }
    public string Dish { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Image { get; set; }
    public string Status { get; set; }
}