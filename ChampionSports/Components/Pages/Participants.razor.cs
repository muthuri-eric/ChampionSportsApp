using ChampionsDbHelper.Models;
using Microsoft.AspNetCore.Components;

namespace ChampionSports.Components.Pages;
public partial class Participants
{
    [Parameter]
    public string? PageRoute { get; set; }
    private SportEvent? sportEvent;
    private Lesson? lesson;
    private Trainee? trainee;
    private IEnumerable<Student>? students;
    private IEnumerable<Student>? participants;
    private IEnumerable<Trainee> trainees;
    private IEnumerable<Equipment> equipments;
    private List<string> selectedEquipments;
    private IEnumerable<Activity>? activities;
    private GradeLevel? gradeLevel;
    private Sport? sport;
    private int[] participantStudentIds = new int[] { 0 };

protected override async Task OnInitializedAsync()
    {

        students = await studentData.GetAllStudentDataAsync();
        sportEvent = await sportEventData.GetSportEventByIdAsync(Convert.ToInt32(PageRoute));
        equipments = await equipmentData.GetAvailableEquipmentsBySportIdAsync(sportEvent.SportId);
        activities = await activityData.GetActivityDataAsync();
        if (sportEvent is not null)
        {
            lesson = await lessonData.GetLessonDataByIdAsync(sportEvent.LessonId);
            trainees = await traineeData.GetTraineeBySportEventIdAsync(sportEvent.SportEventId);
            if (lesson is not null)
            {
                gradeLevel = await gradeLevelData.GetGradeLevelDataByIdAsync(lesson.GradeLevelId);
            }
            sport = await sportData.GetSportByIdAsync(sportEvent.SportId);
        }
        if (students != null && lesson != null)
        {
            participants = students.Where(x => x.GradeLevelId == lesson.GradeLevelId);
        }

    }
    private void LoadEquipmentDetail(int sportEventId, int participantId)
    {
        navManager.NavigateTo($"/equipmentdetail/{sportEventId}/{participantId}");
    }
    private async Task SaveTrainees()
    {
        if (participantStudentIds is not null && participantStudentIds[0] != 0)
        {
            foreach (int id in participantStudentIds)
            {
                await traineeData.SaveTraineeDataAsync(new Trainee
                {
                    StudentId = id,
                    SportEventId = sportEvent.SportEventId,
                });
            }
        }

    }
    private async Task UpdateState(int traineeid)
    {
        var trainee = await traineeData.GetTraineeByIdAsync(traineeid);
        if (trainee != null)
        {
            trainee.Attended = !trainee.Attended;
            await traineeData.UpdateTraineeAsync(trainee);
        }
    }

}