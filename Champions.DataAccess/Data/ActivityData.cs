using ChampionsDbHelper.DataAccess;
using ChampionsDbHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Data;
public class ActivityData : IActivityData
{
    private readonly ISqlDataAccess _db;

    public ActivityData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Activity>> GetActivityDataAsync()
    {
        return await _db.FetchData<Activity, dynamic>("spActivityGetAll", new {});
    }
    public async Task<Activity?> GetActivityById(int id)
    {
        var results = await _db.FetchData<Activity, dynamic>($"select * from dbo.activity where ActivityId = {id}");
        return results.FirstOrDefault();
    }
    public async Task<IEnumerable<Activity?>> GetActivityByTraineeAsync(int traineeId)
    {
        return await _db.FetchData<Activity, dynamic>("spActivityGetByTrainee", new { TraineeId = traineeId });
    }

    public async Task SaveActivityDataAsync(Activity activity)
    {
        await _db.SaveDataAsync("spActivityInsert", new
        {
            activity.TraineeId,
            activity.Description,
            activity.IsCompleted
        });
    }

    public async Task UpdateActivityAsync(Activity activity)
    {
        await _db.UpdateDataAsync("spActivityUpdate", new
        {
            activity.ActivityId,
            activity.TraineeId,
            activity.Description,
            activity.IsCompleted
        });
    }
}
