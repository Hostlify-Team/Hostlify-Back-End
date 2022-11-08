using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public class HistoryDomain : IHistoryDomain
{
    private IHistoryRepository _HistoryRepository;

    public HistoryDomain(IHistoryRepository HistoryRepository)
    {
        _HistoryRepository = HistoryRepository;
    }

    public async Task<List<History>> getAll()
    {
        return await _HistoryRepository.getAll();
    }

    public History getHistoryById(int id)
    {
        return _HistoryRepository.getHistoryById(id);
    }

    public bool createHistory(int roomName, string managerId, int guestId, string guestName, string guestEmail, DateTime initialDate, DateTime endDate, int price, string description)
    {
        throw new NotImplementedException();
    }
}