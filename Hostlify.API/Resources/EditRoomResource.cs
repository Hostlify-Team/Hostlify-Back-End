using System.ComponentModel.DataAnnotations;

namespace Hostlify.API.Resource;

public class EditRoomResource
{
    [Microsoft.Build.Framework.Required]
    [MaxLength(15)]                                                                                         
    public string RoomName { get; set; }
    [Microsoft.Build.Framework.Required]
    public int ManagerId { get; set; }
    public int GuestId { get; set; }
    public string? Description { get; set; }
    public string? Initialdate { get; set; }
    public string? EndDate { get; set; }
    public bool Status { get; set; }
    public bool? GuestStayComplete { get; set; }
    public int? Price { get; set; }
    public bool Emergency { get; set; }
    public bool ServicePending { get; set; }

}