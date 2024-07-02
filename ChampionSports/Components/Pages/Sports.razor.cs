using ChampionsDbHelper.Models;

namespace ChampionSports.Components.Pages;
public partial class Sports
{
    private Sport sport = new();
    private IEnumerable<Sport>? sports;
    protected async override Task OnInitializedAsync()
    {
        sports = await sportData.GetAllSportDataAsync();
    }
    public async Task CreateSport()
    {
        await sportData.SaveSportDataAsync(sport);

    }
}