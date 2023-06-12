namespace Hostlify.API.Resource;

public class UpdateRoomLimitResource
{
    public string actualPlan { get; set; } 
    public string changedPlan { get; set; }
    public int newCustomRoomLimit { get; set; }
}