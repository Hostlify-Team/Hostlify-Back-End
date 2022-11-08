
using System.ComponentModel.DataAnnotations;

namespace Hostlify.API.Resource;

public class RoomResource
{
[Required]
[MaxLength(15)]                                                                                         
public string Name { get; set; }
[Required]
public int ManagerId { get; set; }
}