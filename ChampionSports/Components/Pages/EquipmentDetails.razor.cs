using ChampionsDbHelper.Models;
using Microsoft.AspNetCore.Components;

namespace ChampionSports.Components.Pages;
public partial class EquipmentDetails
{
    [Parameter]
    public int ParticipantId { get; set; }
    [Parameter]
    public int SportEventId { get; set; }
    public IEnumerable<EquipmentDetail> equipmentDetails { get; set; }
    private EquipmentDetail? Detail { get; set; } = new();
    public SportEvent? SportEvent { get; set; }
    public Trainee? Trainee { get; set; }
    public Equipment? AffectedEquipment { get; set; } = new();
    public IEnumerable<Equipment>? AvailableEquipments { get; set; }
    private IEnumerable<Equipment>? Equipments;


    protected override async Task OnInitializedAsync()
    {
        equipmentDetails = await equipmentDetailData.GetEquipmentDetailByTraineeIdAsync(SportEventId, ParticipantId);
        Equipments = await equipmentData.GetAllEquipmentDataAsync();
        SportEvent = await sportEventData.GetSportEventByIdAsync(SportEventId);
        Trainee = await traineeData.GetTraineeByIdAsync(ParticipantId);
        AvailableEquipments = await equipmentData.GetAvailableEquipmentsBySportIdAsync(SportEvent.SportId);
    }
    private async Task SetEquipmentDetail()
    {
        if(AffectedEquipment?.EquipmentId != 0)
        {
            AffectedEquipment = new Equipment
            {
                EquipmentId = AvailableEquipments!.Where(x => x.EquipmentId == Detail!.EquipmentId).FirstOrDefault()!.EquipmentId,
                SportId = AvailableEquipments!.Where(x => x.EquipmentId == Detail!.EquipmentId).FirstOrDefault()!.SportId,
                Description = AvailableEquipments!.Where(x => x.EquipmentId == Detail!.EquipmentId).FirstOrDefault()!.Description,
                StockCount = AvailableEquipments!.Where(x => x.EquipmentId == Detail!.EquipmentId).FirstOrDefault()!.StockCount - 1

            };
            if (AvailableEquipments is not null )
            {
                await equipmentDetailData.InsertEquipmentDetail(new EquipmentDetail
                {
                    EquipmentId = Detail.EquipmentId,
                    TraineeId = ParticipantId,
                    SportEventId = SportEventId,
                    SerialNumber = Detail.SerialNumber,
                    Status = false
                }, AffectedEquipment);
            }
            else
            {
                throw new Exception();
            }
        }
    }
    private async Task UpdateState(int id)
    {
        Detail = await equipmentDetailData.GetEquipmentDetailById(id);
        if (Detail != null)
        {
            Detail.Status = !Detail.Status;
            Detail.ReturnDate = DateTime.Now;
            var equipment = Equipments?.Where(x => x.EquipmentId == Detail.EquipmentId).FirstOrDefault();
            if (equipment != null)
            {
                await equipmentDetailData.UpdateEquipmentDetail(Detail, equipment);
            }
            
        }

    }
}