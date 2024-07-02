using ChampionsDbHelper.DataAccess;
using ChampionsDbHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Data;
public class StudentData : IStudentData
{
    private readonly ISqlDataAccess _db;

    public StudentData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task SaveStudentDataAsync(Student student)
    {
        await _db.SaveDataAsync("spStudentInsert", new
        {
            student.StudentNumber,
            student.Id,
            student.Gender,
            student.GradeLevelId,
            student.FirstName,
            student.LastName

        });
    }
    public async Task<IEnumerable<Student>> GetAllStudentDataAsync()
    {
        return await _db.FetchData<Student, dynamic>("spStudentGetAll", new { });
    }
    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        var results = await _db.FetchData<Student, dynamic>("spStudentGetById", new { StudentId = id });
        return results.FirstOrDefault();
    }
    public async Task UpdateStudentDataAsync(Student student)
    {
        await _db.UpdateDataAsync<dynamic>("spStudentUpdate", new
        {
            student.StudentId,
            student.StudentNumber,
            student.Id,
            student.GradeLevelId,
            student.Gender,
            student.FirstName,
            student.LastName
        });
    }
}
