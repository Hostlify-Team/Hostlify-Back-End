using System.ComponentModel.DataAnnotations;

namespace Hostlify.API.Resource;

public class RoomResource
{
    [Microsoft.Build.Framework.Required]
    [MaxLength(15)]                                                                                         
    public string RoomName { get; set; }
    [Microsoft.Build.Framework.Required]
    public int ManagerId { get; set; }
    
    public string Description { get; set; }
}