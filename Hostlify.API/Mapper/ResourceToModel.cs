using AutoMapper;
using Hostlify.API.Resource;
using Hostlify.Infraestructure;

namespace Hostlify.API.Mapper;

public class ResourceToModel:Profile
{
    public ResourceToModel()
    {
        CreateMap<PlanResource, Plan>();
        CreateMap<UserResource, User>();
        CreateMap<LoginResource, User>();
        CreateMap<RoomResource, Room>();
        CreateMap<EditRoomResource, Room>();
        CreateMap<FoodServicesResource, FoodServices>();
        CreateMap<HistoryResource, History>();
    }
}