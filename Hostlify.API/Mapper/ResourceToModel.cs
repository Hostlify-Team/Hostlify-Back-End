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
        CreateMap<RoomResource, Room>();
        CreateMap<FoodServicesResource, FoodServices>();
    }
}