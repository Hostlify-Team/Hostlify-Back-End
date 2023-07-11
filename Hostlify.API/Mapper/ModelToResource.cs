using AutoMapper;
using Hostlify.API.Resource;
using Hostlify.Infraestructure;

namespace Hostlify.API.Mapper;

public class ModelToResource:Profile
{
    public ModelToResource()
    {
        CreateMap<User, UserResource>();
        CreateMap<User, GuestUserResource>();
        CreateMap<User, GetUserResponse>();
        CreateMap<User, LoginResource>();
        CreateMap<User, LoginUserResponse>();
        CreateMap<Room, RoomResource>();
        CreateMap<Room, GetRoomResponse>();
        CreateMap<Room, UpdateRoomRegisteredResource>();
        CreateMap<Room, RegisterGuestResource>();
        CreateMap<Room, UpdateRoomEmptyResource>();
        CreateMap<RoomResource, UpdateRoomRegisteredResource>();
        CreateMap<Room, EditRoomResource>();
        CreateMap<History, HistoryResource>();
        CreateMap<History, getHistoryResponse>();
        CreateMap<FoodServices, FoodServicesResource>();
        CreateMap<FoodServices, GetFoodServiceResponse>();
        CreateMap<CleaningServices, PostCleaningServiceResource>();
        CreateMap<CleaningServices, getCleaningServiceResponse>();

        
    }
}