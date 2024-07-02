using ChampionsDbHelper.Models;

namespace ChampionsDbHelper.Data;
public interface IGradeLevelData
{
    Task<IEnumerable<GradeLevel>> GetAllGradeLevelDataAsync();
    Task<GradeLevel?> GetGradeLevelDataByIdAsync(int id);
    Task SaveGradeLevelDataAsync(GradeLevel gradeLevel);
    Task UpdateGradeLevelDataAsync(GradeLevel gradeLevel);
}