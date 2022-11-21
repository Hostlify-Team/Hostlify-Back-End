using AutoMapper;
using Hostlify.API.Resource;
using Hostlify.Infraestructure;

namespace Hostlify.API.Mapper;

public class ModelToResource:Profile
{
    public ModelToResource()
    {
        CreateMap<Plan, PlanResource>();
        CreateMap<User, UserResource>();
        CreateMap<User, LoginResource>();
        CreateMap<Room, RoomResource>();
        CreateMap<Room, EditRoomResource>();
        CreateMap<History, HistoryResource>();
        CreateMap<FoodServices, FoodServicesResource>();
        
    }
}