using ChampionsDbHelper.DataAccess;
using ChampionsDbHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Data;
public class LessonData : ILessonData
{
    private readonly ISqlDataAccess _db;

    public LessonData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task SavelessonDataAsync(Lesson lesson)
    {
        await _db.SaveDataAsync("spLessonInsert", new
        {
            lesson.GradeLevelId,
            lesson.SubjectId,
            lesson.LessonDate,
            lesson.StartTime,
            lesson.EndTime
        });
    }
    public async Task<IEnumerable<Lesson>> GetAllLessonDataAsync()
    {
        return await _db.FetchData<Lesson, dynamic>("spLessonGetAll", new { });
    }
    public async Task<Lesson?> GetLessonDataByIdAsync(int id)
    {
        var results = await _db.FetchData<Lesson, dynamic>("spLessonGetById", new { LessonId = id });
        return results.FirstOrDefault();
    }
    public async Task UpdatelessonDataAsync(Lesson lesson)
    {
        await _db.UpdateDataAsync("spLessonUpdate", new
        {
            lesson.GradeLevelId,
            lesson.SubjectId,
            lesson.LessonDate,
            lesson.StartTime,
            lesson.EndTime
        });
    }
}
