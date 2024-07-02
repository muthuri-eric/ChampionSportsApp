using ChampionsDbHelper.DataAccess;
using ChampionsDbHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Data;
public class EquipmentData : IEquipmentData
{
    private readonly ISqlDataAccess _db;

    public EquipmentData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task SaveEquipmentDataAsync(Equipment equipment)
    {
        await _db.SaveDataAsync("spEquipmentInsert", new
        {
            equipment.SportId,
            equipment.Description,
            equipment.StockCount
        });
    }

    public async Task<IEnumerable<Equipment>> GetAllEquipmentDataAsync()
    {
        return await _db.FetchData<Equipment, dynamic>("spEquipmentGetAll", new
        {
        });
    }
    public async Task<IEnumerable<Equipment>> GetAvailableEquipmentsBySportIdAsync(int sportId)
    {
        return await _db.FetchData<Equipment, dynamic>($"select * from dbo.Equipment where StockCount > 0 AND SportId = {sportId}");
    }
    public async Task<IEnumerable<Equipment>> GetEquipmentByIdAsync(int id)
    {
        return await _db.FetchData<Equipment, dynamic>("spEquipmentGetById", new { Id = id });
    }
    public async Task UpdateEquipmentDataAsync(Equipment equipment)
    {
        await _db.UpdateDataAsync("spEquipmentUpdate", new
        {
            equipment.SportId,
            equipment.Description,
            equipment.StockCount
        });
    }
}
