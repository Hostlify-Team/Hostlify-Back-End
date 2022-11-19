﻿using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface IHistoryDomain
{
    Task<List<History>> getAll();
   
   
    Task<bool> postHistory(History history);
    
    Task<History> getHistoryForManagerId(int managerId);
    
    Task<bool> deleteHistory(int id);
}