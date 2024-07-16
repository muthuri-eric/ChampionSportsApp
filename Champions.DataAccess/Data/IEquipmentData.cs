using ChampionsDbHelper.Models;

namespace ChampionsDbHelper.Data;
public interface IEquipmentData
{
    Task<IEnumerable<Equipment>> GetAllEquipmentDataAsync();
    Task<IEnumerable<Equipment>> GetAvailableEquipmentsBySportIdAsync(int sportId);
    Task<Equipment?> GetEquipmentByIdAsync(int id);
    Task SaveEquipmentDataAsync(Equipment equipment);
    Task UpdateEquipmentDataAsync(Equipment equipment);
}