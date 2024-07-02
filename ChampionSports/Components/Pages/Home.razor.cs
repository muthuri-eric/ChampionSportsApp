using ChampionsDbHelper.Models;

namespace ChampionSports.Components.Pages;
public partial class Home
{
    private SportEvent sportEvent = new();
    private IEnumerable<SportEvent>? sportEvents;
    private IEnumerable<Lesson>? lessons;
    private IEnumerable<Sport>? sports;
    private IEnumerable<GradeLevel>? gradeLevels;
    public List<DateTime> _dates { get; set; } = new();
    protected async override Task OnInitializedAsync()
    {
        sportEvents = await eventsData.GetAllSportEventsDataAsync();
        lessons = await lessonData.GetAllLessonDataAsync();
        gradeLevels = await gradeLevelData.GetAllGradeLevelDataAsync();
        sports = await sportData.GetAllSportDataAsync();
        foreach (var sp in sportEvents)
        {
            sp.EventDate = lessons.Where(x => x.LessonId == sp.LessonId).FirstOrDefault().LessonDate;
            if (sp.EventDate >= DateTime.Now)
            {
                _dates.Add(sp.EventDate);
            }
        }
        sportEvents = sportEvents.OrderByDescending(sp => sp.EventDate);
    }
}