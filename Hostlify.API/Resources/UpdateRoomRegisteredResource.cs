﻿namespace Hostlify.API.Resource;

public class UpdateRoomRegisteredResource
{
    public string RoomName { get; set; }
    public int GuestId { get; set; }
    public int ManagerId { get; set; }
    public string Initialdate { get; set; }
    public string EndDate { get; set; }
    public bool Status { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public bool Emergency { get; set; }
    public bool ServicePending { get; set; }
}