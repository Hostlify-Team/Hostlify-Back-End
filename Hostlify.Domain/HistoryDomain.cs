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
    public async Task<bool> postHistory(History history)
    {
        return await _HistoryRepository.postHistory(history);
    }

    public async Task<List<History>> getHistoryForManagerId(int managerId)
    {
        return await _HistoryRepository.getHistoryForManagerId(managerId);
    }

    public async Task<bool> deleteHistory(int id)
    {
        return await _HistoryRepository.deleteHistory(id);
    }


}