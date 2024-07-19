using ChampionsDbHelper.Models;
using ChampionSports.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace ChampionSports.Components.Pages;
public partial class Matches
{
    private SportEvent sportEvent = new();
    private Lesson lesson = new();
    private Sport sport = new();
    private Trainer? trainer = new();
    private IEnumerable<Sport>? sports;
    private IEnumerable<Trainer?> trainers;
    private IEnumerable<Subject> subjects;
    private IEnumerable<GradeLevel> gradeLevels;
    private IEnumerable<Student> students;
    private Lesson selectedLesson = new();
    [CascadingParameter]
    private Task<AuthenticationState> Auth { get; set; }
    private ApplicationUser _loggedInUser;
    public SearchModel Model { get; set; } = new();
    private IEnumerable<SportEvent?> sportEvents;
    private IEnumerable<SportEvent?> orderedEvents;
    private IEnumerable<Lesson>? lessons;
    protected async override Task OnInitializedAsync()
    {
        lessons = await lessonData.GetAllLessonDataAsync();
        sports = await sportData.GetAllSportDataAsync();
        trainers = await trainerData.GetAllTrainerDataAsync();
        students = await studentData.GetAllStudentDataAsync();
        subjects = await subjectData.GetAllSubjectData();
        gradeLevels = await gradeLevelData.GetAllGradeLevelDataAsync();
        var auth = await Auth;
        var user = auth.User;
        _loggedInUser = await userManager.GetUserAsync(user);
        trainer = trainers.Where(x => x.Id == _loggedInUser.Id).FirstOrDefault();
        if (await userManager.IsInRoleAsync(_loggedInUser, "Admin"))
        {
            sportEvents = await eventsData.GetAllSportEventsDataAsync();
            foreach (var sp in sportEvents)
            {
                sp.EventDate = lessons.Where(x => x.LessonId == sp.LessonId).FirstOrDefault().LessonDate;
                var sptrainees = await traineeData.GetTraineeBySportEventIdAsync(sp.SportEventId);
                if (sptrainees is not null && sptrainees.Count() > 0)
                {
                    sp.IsFullyAttended = sptrainees.Count() == sptrainees.Where(x => x.Attended).Count() ? true : false;
                }

            }
            orderedEvents = sportEvents.OrderByDescending(sp => sp.EventDate);
        }
        if (trainer is not null)
        {
            sportEvents = await eventsData.GetUserSportEvents(trainers.Where(x => x.Id == _loggedInUser.Id).FirstOrDefault().TrainerId);
            foreach (var sp in sportEvents)
            {
                sp.EventDate = lessons.Where(x => x.LessonId == sp.LessonId).FirstOrDefault()!.LessonDate;
                var sptrainees = await traineeData.GetTraineeBySportEventIdAsync(sp.SportEventId);
                if (sptrainees is not null && sptrainees.Count() > 0)
                {
                    sp.IsFullyAttended = sptrainees.Count() == sptrainees.Where(x => x.Attended).Count() ? true : false;
                }
            }
            orderedEvents = sportEvents.OrderByDescending(sp => sp.EventDate);
        }
        if (await userManager.IsInRoleAsync(_loggedInUser, "Trainer"))
        {
            trainers = trainers.Where(x => x.Id == _loggedInUser.Id);
        }

    }
    private async Task CreateSportEvent()
    {
        if(lessons is not null)
        {
            sportEvent.StartTime = lessons.Where(x => x.LessonId == sportEvent.LessonId).FirstOrDefault()!.StartTime;
            sportEvent.EndTime = lessons.Where(x => x.LessonId == sportEvent.LessonId).FirstOrDefault()!.EndTime;
            await eventsData.SaveSportEventDataAsync(sportEvent);
        }

    }
    private void LoadParticipants(int sportEventId)
    {
        navManager.NavigateTo($"/participants/{sportEventId}");
    }
    private void LoadPreview()
    {
        navManager.NavigateTo($"/attendance");
    }

    private void Filter(int id)
    {
        var orderedEventsTemp = sportEvents.OrderByDescending(sp => sp.EventDate);
        orderedEvents = orderedEventsTemp.Where(x => x.SportId == id);
    }

}