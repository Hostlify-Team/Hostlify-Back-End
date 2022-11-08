﻿using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface IFoodServicesDomain
{
    Task<List<FoodServices>> getAll();
    Task<bool> postfoodservice(FoodServices foodServices);
    Task<FoodServices>  getFoodServiceByRoomId(int roomId);
    
    Task<bool> deletebyRoomID(int roomId);
    
    Task<bool> deletebyid(int id);
}