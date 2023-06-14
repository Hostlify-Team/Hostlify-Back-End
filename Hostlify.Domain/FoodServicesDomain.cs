﻿using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public class FoodServicesDomain :  IFoodServicesDomain
{

    private IFoodServicesRepository _FoodServicesRepository;
    //private IFoodServicesDomain _foodServicesDomainImplementation;


    public FoodServicesDomain(IFoodServicesRepository foodServicesRepository)
    {
        _FoodServicesRepository = foodServicesRepository;
    }


    public async Task<List<FoodServices>> getAll()
    {
        return await _FoodServicesRepository.getAll();
    }

    public async Task<bool> postfoodservice(FoodServices foodServices)
    {
        return await _FoodServicesRepository.postfoodservice(foodServices);
    }

    public async Task<List<FoodServices>> getFoodServiceByRoomId(int roomId)
    {
        return await _FoodServicesRepository.getFoodServiceByRoomId(roomId);
    }

    public async Task<List<FoodServices>> getFoodServiceAttendedByRoomId(int roomId)
    {
        return await _FoodServicesRepository.getFoodServiceAttendedByRoomId(roomId);
    }

    public async Task<List<FoodServices>> getFoodServiceUnAttendedByRoomId(int roomId)
    {
        return await _FoodServicesRepository.getFoodServiceUnAttendedByRoomId(roomId);
    }

    public async Task<bool> deleteAllFoodServicesByRoomId(int id)
    {
        return await _FoodServicesRepository.deleteAllFoodServicesByRoomId(id);
    }

    public async Task<bool> attendByid(int id)
    {
        return await _FoodServicesRepository.attendByid(id);
    }
}