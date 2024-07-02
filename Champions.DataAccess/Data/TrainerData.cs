using ChampionsDbHelper.DataAccess;
using ChampionsDbHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Data;
public class TrainerData : ITrainerData
{
    private readonly ISqlDataAccess _db;

    public TrainerData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task SaveTrainerDataAsync(Trainer trainer)
    {
        await _db.SaveDataAsync("spTrainerInsert", new
        {
            trainer.Id,
            trainer.StaffNumber,
            trainer.Title,
            trainer.FirstName,
            trainer.LastName

        });
    }
    public async Task<IEnumerable<Trainer>> GetAllTrainerDataAsync()
    {
        return await _db.FetchData<Trainer, dynamic>("spTrainerGetAll", new { });
    }
    public async Task<Trainer?> GetTrainerByIdAsync(int id)
    {
        var results = await _db.FetchData<Trainer, dynamic>("spTrainerGetById", new { TrainerId = id });
        return results.FirstOrDefault();
    }
    public async Task UpdateTrainerDataAsync(Trainer trainer)
    {
        await _db.UpdateDataAsync("spTrainerUpdate", new
        {
            trainer.TrainerId,
            trainer.Id,
            trainer.StaffNumber,
            trainer.Title,
            trainer.FirstName,
            trainer.LastName
        });
    }

}
