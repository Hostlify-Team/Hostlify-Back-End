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

    public async Task<History> getHistoryForManager(int id)
    {
        return await _HistoryRepository.getHistoryForManager(id);
    }

    public async Task<bool> deleteHistory(int id)
    {
        return await _HistoryRepository.deleteHistory(id);
    }

    public async Task<bool> post(History history)
    {
        return await _HistoryRepository.post(history);
    }
}