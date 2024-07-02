using ChampionsDbHelper.Models;

namespace ChampionsDbHelper.Data;
public interface ITrainerData
{
    Task<IEnumerable<Trainer>> GetAllTrainerDataAsync();
    Task<Trainer?> GetTrainerByIdAsync(int id);
    Task SaveTrainerDataAsync(Trainer trainer);
    Task UpdateTrainerDataAsync(Trainer trainer);
}