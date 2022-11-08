using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface IHistoryDomain
{
    Task<List<History>> getAll();
    History getHistoryById(int id);
    Boolean createHistory(int roomName, string managerId, int guestId, string guestName, string guestEmail, DateTime initialDate, DateTime endDate, int price, string description);
    
    Task<History> getHistoryForManager(int id);
    
    Task<bool> deleteHistory(int id);

    Task<bool> post(History history);
}