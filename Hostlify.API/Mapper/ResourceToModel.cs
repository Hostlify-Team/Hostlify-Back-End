﻿using AutoMapper;
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
        CreateMap<RoomResource, Room>();
        CreateMap<GetRoomResponse, Room>();
        CreateMap<UpdateRoomRegisteredResource, Room>();
        CreateMap<UpdateRoomRegisteredResource, RoomResource>();
        CreateMap<EditRoomResource, Room>();
        CreateMap<FoodServicesResource, FoodServices>();
        CreateMap<GetFoodServiceResponse, FoodServices>();
        CreateMap<HistoryResource, History>();
        CreateMap<getHistoryResponse, History>();

    }
}