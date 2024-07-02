using ChampionsDbHelper.Models;

namespace ChampionSports.Components.Pages;
public partial class Lessons
{
    private Lesson lesson = new();
    private GradeLevel gradeLevel = new();
    private IEnumerable<Lesson>? peLessons;
    private IEnumerable<GradeLevel> gradeLevels;
    private IEnumerable<Subject> subjects;
    protected async override Task OnInitializedAsync()
    {
        peLessons = await lessonData.GetAllLessonDataAsync();
        gradeLevels = await gradeLevelData.GetAllGradeLevelDataAsync();
        subjects = await subjectData.GetAllSubjectData();
    }
    private async Task CreateLesson()
    {
        await lessonData.SavelessonDataAsync(lesson);
    }
}