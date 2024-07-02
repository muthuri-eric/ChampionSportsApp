using ChampionsDbHelper.Models;

namespace ChampionsDbHelper.Data;
public interface ITraineeData
{
    Task<IEnumerable<Trainee>> GetAllTraineesAsync();
    Task<Trainee?> GetTraineeByIdAsync(int id);
    Task<IEnumerable<Trainee>> GetTraineeBySportEventIdAsync(int sportEventId);
    Task<IEnumerable<Trainee>> GetTraineeByStudentIdAsync(int studentId);
    Task SaveTraineeDataAsync(Trainee trainee);
    Task UpdateTraineeAsync(Trainee trainee);
}