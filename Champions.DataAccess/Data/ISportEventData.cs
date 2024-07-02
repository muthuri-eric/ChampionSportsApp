using ChampionsDbHelper.Models;

namespace ChampionsDbHelper.Data;
public interface ISportEventData
{
    Task<IEnumerable<SportEvent>> GetAllSportEventsDataAsync();
    Task<SportEvent?> GetSportEventByIdAsync(int id);
    Task<IEnumerable<SportEvent?>> GetUserSportEvents(int id);
    Task SaveSportEventDataAsync(SportEvent sportEvent);
    Task UpdateSportEventAsync(SportEvent sportEvent);
}