﻿using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface IFoodServicesDomain
{
    Task<List<FoodServices>> getAll();
    Task<bool> postfoodservice(FoodServices foodServices);
    Task<FoodServices>  getFoodServiceByRoomId(int roomId);
    
    Task<bool> deletebyroomid(int roomid);
    
    Task<bool> deletebyid(int id);
}