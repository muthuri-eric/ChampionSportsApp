using ChampionsDbHelper.DataAccess;
using ChampionsDbHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Data;
public class SportData : ISportData
{
    private readonly ISqlDataAccess _db;

    public SportData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task SaveSportDataAsync(Sport sport)
    {
        await _db.SaveDataAsync("spSportInsert", new
        {
            //sport.SportId,
            sport.SportDescription
        });
    }
    public async Task<IEnumerable<Sport>> GetAllSportDataAsync()
    {
        return await _db.FetchData<Sport, dynamic>("spSportGetAll", new
        {
        });
    }
    public async Task<Sport?> GetSportByIdAsync(int id)
    {
        var results = await _db.FetchData<Sport, dynamic>("spSportGetById", new { SportId = id });
        return results.FirstOrDefault();

    }
    public async Task UpdateSportDataAsync(Sport sport)
    {
        await _db.UpdateDataAsync("spSportUpdate", new
        {
            sport.SportId,
            sport.SportDescription
        });
    }
}
