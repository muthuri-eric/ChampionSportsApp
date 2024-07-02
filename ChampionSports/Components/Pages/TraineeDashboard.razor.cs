using ChampionsDbHelper.Models;
using ChampionSports.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace ChampionSports.Components.Pages;
public partial class TraineeDashboard
{
    private Activity Activity { get; set; } = new();
    [CascadingParameter]
    private Task<AuthenticationState> Auth { get; set; }
    private ApplicationUser _loggedInUser;
    public string Message { get; set; }
    public bool IsAcceptStatus { get; set; }
    public IEnumerable<SportEvent?> SportEvents { get; set; }
    public SportEvent SportEvent { get; set; }
    public IEnumerable<GradeLevel?> GradeLevels { get; set; }
    public IEnumerable<Lesson?> Lessons { get; set; }
    public IEnumerable<Sport?> Sports { get; set; }
    private IEnumerable<Trainee> trainees;
    private IEnumerable<Student> students;
    private IEnumerable<Equipment> equipments;
    private Student? student;

    protected override async Task OnInitializedAsync()
    {
        students = await studentData.GetAllStudentDataAsync();
        SportEvents = await eventData.GetAllSportEventsDataAsync();
        Lessons = await lessonData.GetAllLessonDataAsync();
        GradeLevels = await gradeLevelData.GetAllGradeLevelDataAsync();
        Sports = await sportData.GetAllSportDataAsync();
        equipments = await equipmentData.GetAllEquipmentDataAsync();

        var auth = await Auth;
        var user = auth.User;
        _loggedInUser = await userManager.GetUserAsync(user);

        student = students.Where(x => x.Id == _loggedInUser.Id).FirstOrDefault();
        if (student != null)
        {
            trainees = await traineeData.GetTraineeByStudentIdAsync(student.StudentId);
        }

        if (trainees != null)
        {
            foreach (var trainee in trainees)
            {
                SportEvent = await eventData.GetSportEventByIdAsync(trainee.SportEventId);
            }
        }
    }
    public async Task SubmitActivity(Activity activity, int id)
    {
        Activity.TraineeId = id;
        await activityData.SaveActivityDataAsync(Activity);
    }
    public async Task UpdateState(int traineeId)
    {
        bool flag = false;
        var trainee = await traineeData.GetTraineeByIdAsync(traineeId);
        if (trainee != null)
        {
            trainee.Accepted = !flag;
            await traineeData.UpdateTraineeAsync(trainee);
            flag = true;
        }
        Message = IsAcceptStatus ? "Accepted" : "Not Accepted, please confirm attendance";
    }
    public async Task UpdateActivity(int activityId)
    {
        bool flag = false;
        var activity = await activityData.GetActivityById(activityId);
        if (activity != null)
        {
            activity.IsCompleted = !flag;
            await activityData.UpdateActivityAsync(activity);
            flag = true;
        }
    }
}