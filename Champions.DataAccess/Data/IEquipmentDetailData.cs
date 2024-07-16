using ChampionsDbHelper.Models;

namespace ChampionsDbHelper.Data;
public interface IEquipmentDetailData
{
    Task<EquipmentDetail?> GetEquipmentDetailById(int id);
    Task<IEnumerable<EquipmentDetail>> GetEquipmentDetailByTraineeIdAsync(int sportEventId, int participantId);
    Task InsertEquipmentDetail(EquipmentDetail detail, Equipment equipment, string connectiodId = "Default");
    Task UpdateEquipmentDetail(EquipmentDetail detail, Equipment equipment, string connectionId = "Default");
}