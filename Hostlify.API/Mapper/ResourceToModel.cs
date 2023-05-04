using AutoMapper;
using Hostlify.API.Resource;
using Hostlify.Infraestructure;

namespace Hostlify.API.Mapper;

public class ResourceToModel:Profile
{
    public ResourceToModel()
    {
        CreateMap<UserResource, User>();
        CreateMap<GuestUserResource, User>();
        CreateMap<GetUserResponse, User>();
        CreateMap<LoginResource, User>();
        CreateMap<LoginUserResponse, User>();
        CreateMap<RoomResource, Room>();
        CreateMap<GetRoomResponse, Room>();
        CreateMap<UpdateRoomRegisteredResource, Room>();
        CreateMap<RegisterGuestResource, Room>();
        CreateMap<UpdateRoomEmptyResource, Room>();
        CreateMap<UpdateRoomRegisteredResource, RoomResource>();
        CreateMap<EditRoomResource, Room>();
        CreateMap<FoodServicesResource, FoodServices>();
        CreateMap<GetFoodServiceResponse, FoodServices>();
        CreateMap<HistoryResource, History>();
        CreateMap<getHistoryResponse, History>();
        CreateMap<PostCleaningServiceResource, CleaningServices>();
        CreateMap<getCleaningServiceResponse, CleaningServices>();
        CreateMap<postRoomLimitResource, PersonalPlan>();

    }
}