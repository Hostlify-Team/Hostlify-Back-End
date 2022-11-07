using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface IHistoryDomain
{
    Task<List<History>> getAll();
    History getHistoryById(int id);
    Boolean createHistory(int roomName, string managerId, int guestId, string guestName, string guestEmail, int initialDate, int endDate, int price, string description);
}