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
        CreateMap<Room, RoomResource>();
        CreateMap<FoodServices, FoodServicesResource>();
    }
}