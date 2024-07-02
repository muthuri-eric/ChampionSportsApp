using ChampionsDbHelper.DataAccess;
using ChampionsDbHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Data;
public class TraineeData : ITraineeData
{
    private readonly ISqlDataAccess _db;

    public TraineeData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task SaveTraineeDataAsync(Trainee trainee)
    {
        await _db.SaveDataAsync("spTraineeInsert", new
        {
            trainee.StudentId,
            trainee.SportEventId,
            trainee.Accepted,
            trainee.Attended
        });
    }
    public async Task<IEnumerable<Trainee>> GetAllTraineesAsync()
    {
        return await _db.FetchData<Trainee, dynamic>("spTraineeGetAll", new { });
    }
    public async Task<Trainee?> GetTraineeByIdAsync(int id)
    {
        var results = await _db.FetchData<Trainee, dynamic>("spTraineeGetById", new { TraineeId = id });
        return results.FirstOrDefault();
    }
    public async Task<IEnumerable<Trainee>> GetTraineeBySportEventIdAsync(int sportEventId)
    {
        var trainees = await _db.FetchData<Trainee, dynamic>($"Select * from dbo.Trainee where SportEventId = {sportEventId}");
        var activities = await _db.FetchData<Activity, dynamic>("spActivityGetAll", new { });
        var equipmentsdtl = await _db.FetchData<EquipmentDetail, dynamic>("spEquipmentDetailGetAll", new { });
        var equipments = await _db.FetchData<Equipment, dynamic>("spEquipmentGetAll", new { });
        foreach (var trainee in trainees)
        {
            trainee.Activities = activities.Where(x => x.TraineeId == trainee.TraineeId).ToList();
            trainee.Equipments = equipmentsdtl.Where(x => x.TraineeId == trainee.TraineeId).ToList();
        }
        return trainees;
    }
    public async Task<IEnumerable<Trainee>> GetTraineeByStudentIdAsync(int studentId)
    {
        var trainees = await _db.FetchData<Trainee, dynamic>($"Select * from dbo.Trainee where StudentId = {studentId}");
        var activities = await _db.FetchData<Activity, dynamic>("spActivityGetAll", new { });
        var equipmentsdtl = await _db.FetchData<EquipmentDetail, dynamic>("spEquipmentDetailGetAll", new { });
        var equipments = await _db.FetchData<Equipment, dynamic>("spEquipmentGetAll", new { });
        foreach ( var trainee in trainees)
        {
            trainee.Activities = activities.Where(x => x.TraineeId == trainee.TraineeId).ToList();
            trainee.Equipments = equipmentsdtl.Where(x => x.TraineeId == trainee.TraineeId).ToList();         
        }
        return trainees;
    }
    public async Task UpdateTraineeAsync(Trainee trainee)
    {
        await _db.UpdateDataAsync<dynamic>("spTraineeUpdate", new
        {
            trainee.TraineeId,
            trainee.StudentId,
            trainee.SportEventId,
            trainee.Accepted,
            trainee.Attended
        });
    }
}
