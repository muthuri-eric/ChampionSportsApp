using ChampionsDbHelper.Models;

namespace ChampionSports.Components.Pages;
public partial class Equipments
{
    private Equipment equipment = new();
    private IEnumerable<Equipment>? equipments;
    private IEnumerable<Sport> sports;
    protected async override Task OnInitializedAsync()
    {
        equipments = await equipmentData.GetAllEquipmentDataAsync();
        sports = await sportData.GetAllSportDataAsync();
    }
    public async Task CreateEquipments()
    {
        await equipmentData.SaveEquipmentDataAsync(equipment);

    }
    public async Task UpdateEquipments()
    {

        await equipmentData.UpdateEquipmentDataAsync(equipment);
    }
}