using ChampionsDbHelper.DataAccess;
using ChampionsDbHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Data;
public class GradeLevelData : IGradeLevelData
{
    private readonly ISqlDataAccess _db;

    public GradeLevelData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task SaveGradeLevelDataAsync(GradeLevel gradeLevel)
    {
        await _db.SaveDataAsync("spGradeLevelInsert", new
        {
            gradeLevel.GradeNumber,
            gradeLevel.Description

        });
    }
    public async Task<IEnumerable<GradeLevel>> GetAllGradeLevelDataAsync()
    {
        return await _db.FetchData<GradeLevel, dynamic>("spGradeLevelGetAll", new { });
    }
    public async Task<GradeLevel?> GetGradeLevelDataByIdAsync(int id)
    {
        var results = await _db.FetchData<GradeLevel, dynamic>("spGradeLevelGetById", new { GradeLevelId = id });
        return results.FirstOrDefault();
    }
    public async Task UpdateGradeLevelDataAsync(GradeLevel gradeLevel)
    {
        await _db.UpdateDataAsync("spGradeLevelUpdate", new
        {
            gradeLevel.GradeNumber,
            gradeLevel.Description
        });
    }
}