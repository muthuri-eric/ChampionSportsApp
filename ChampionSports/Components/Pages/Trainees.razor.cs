using ChampionsDbHelper.Models;

namespace ChampionSports.Components.Pages;
public partial class Trainees
{
    private Trainee trainee = new();

    private IEnumerable<Trainee> trainees;
    protected override async Task OnInitializedAsync()
    {
        trainees = await traineeData.GetAllTraineesAsync();
    }
    private async Task AddTrainee()
    {
        await traineeData.SaveTraineeDataAsync(trainee);
    }
}