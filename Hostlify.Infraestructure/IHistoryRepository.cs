namespace Hostlify.Infraestructure;

public interface IHistoryRepository
{
    Task<List<History>> getAll();
   
   
    Task<bool> postHistory(History history);
    
    Task<List<History>> getHistoryForManagerId(int managerId);
    
    Task<bool> deleteHistory(int id);

   
}