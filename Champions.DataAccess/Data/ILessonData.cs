using ChampionsDbHelper.Models;

namespace ChampionsDbHelper.Data;
public interface ILessonData
{
    Task<IEnumerable<Lesson>> GetAllLessonDataAsync();
    Task<Lesson?> GetLessonDataByIdAsync(int id);
    Task SavelessonDataAsync(Lesson lesson);
    Task UpdatelessonDataAsync(Lesson lesson);
}