using ChampionsDbHelper.Models;

namespace ChampionsDbHelper.Data;
public interface IStudentData
{
    Task<IEnumerable<Student>> GetAllStudentDataAsync();
    Task<Student?> GetStudentByIdAsync(int id);
    Task SaveStudentDataAsync(Student student);
    Task UpdateStudentDataAsync(Student student);
}