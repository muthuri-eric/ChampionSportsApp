using ChampionsDbHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Data;
public interface IActivityData
{
    Task<IEnumerable<Activity>> GetActivityDataAsync();
    Task<Activity?> GetActivityById(int id);
    Task<IEnumerable<Activity?>> GetActivityByTraineeAsync(int traineeId);
    Task SaveActivityDataAsync(Activity activity);
    Task UpdateActivityAsync(Activity activity);
}
