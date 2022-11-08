using System.ComponentModel.DataAnnotations;

namespace Hostlify.API.Resource;

public class PlanResource
{
    [Required]
    [MaxLength(15)]
    public string Name { get; set; }
    
    public int Rooms { get; set; }
    
    [Required]
    public int Price { get; set; }
}