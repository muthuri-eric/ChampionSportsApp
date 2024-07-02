using ChampionsDbHelper.DataAccess;
using ChampionsDbHelper.Models;
using System.Data;

namespace ChampionsDbHelper.Data;
public class SportEventData : ISportEventData
{
    private readonly ISqlDataAccess _db;

    public SportEventData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task SaveSportEventDataAsync(SportEvent sportEvent)
    {
        await _db.SaveDataAsync("spSportEventInsert", new
        {
            sportEvent.LessonId,
            sportEvent.SportId,
            sportEvent.TrainerId,
            sportEvent.MatchDescription,
            sportEvent.Location,
            sportEvent.StartTime,
            sportEvent.EndTime
        });
    }
    public async Task<IEnumerable<SportEvent>> GetAllSportEventsDataAsync()
    {
        var results = await _db.FetchData<SportEvent, dynamic>("spSportEventGetAll", new { });
        foreach (var sp in results)
        {
            var lessons = await _db.FetchData<Lesson, dynamic>("spLessonGetById", new { LessonId = sp.LessonId });
            sp.EventDate = lessons.Where(x => x.LessonId == sp.LessonId).FirstOrDefault().LessonDate;
        }
        return results;
    }    
    public async Task<SportEvent?> GetSportEventByIdAsync(int id)
    {
        var results = await _db.FetchData<SportEvent, dynamic>("spSportEventGetById", new {SportEventId = id});
        return results.FirstOrDefault();
    }
    public async Task<IEnumerable<SportEvent?>> GetUserSportEvents(int id)
    {
        return await _db.FetchData<SportEvent, dynamic>($"select * from dbo.SportEvent where TrainerId = {id}");
    }
    public async Task UpdateSportEventAsync(SportEvent sportEvent)
    {
        await _db.UpdateDataAsync<dynamic>("spSportEventUpdate", new
        {
            sportEvent.LessonId,
            sportEvent.SportId,
            sportEvent.TrainerId,
            sportEvent.MatchDescription,
            sportEvent.Location,
            sportEvent.StartTime,
            sportEvent.EndTime
        });

    }

}
