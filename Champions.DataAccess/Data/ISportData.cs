using ChampionsDbHelper.Models;

namespace ChampionsDbHelper.Data;
public interface ISportData
{
    Task<IEnumerable<Sport>> GetAllSportDataAsync();
    Task<Sport?> GetSportByIdAsync(int id);
    Task SaveSportDataAsync(Sport sport);
    Task UpdateSportDataAsync(Sport sport);
}