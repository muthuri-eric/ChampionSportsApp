using ChampionsDbHelper.Models;

namespace ChampionSports.Components.Pages;
public partial class Attendance
{
    public SearchModel Model { get; set; } = new();
    private IEnumerable<Sport>? sports;
    public List<Trainee> Trainees { get; set; } = new();
    public List<Student> AttendedStudents { get; set; } = new();
    public List<Student> StudentTrainees { get; set; } = new();
    public IEnumerable<SportEvent> SportEvents { get; set; }
    public IEnumerable<Student> Students { get; set; }
    private int participants;
    private int participantsAttended;
    private int events;
    private int maleAttendees;
    private int femaleAttendees;
    protected override async Task OnInitializedAsync()
    {
        sports = await sportData.GetAllSportDataAsync();
        Students = await studentData.GetAllStudentDataAsync();
    }
    private async Task Search()
    {
        var sportEvents1 = await sportEventData.GetAllSportEventsDataAsync();
        var sportEvents = sportEvents1.Where(x => x.EventDate > Model.FromDate && x.EventDate < Model.ToDate && x.SportId == Model.Id);
        maleAttendees = 0;
        femaleAttendees = 0;
        foreach (var sp in sportEvents)
        {
            var sptrainees = await traineeData.GetTraineeBySportEventIdAsync(sp.SportEventId);

            if (sptrainees is not null && sptrainees.Count() > 0)
            {
                foreach (var tr in sptrainees)
                {
                    Trainees.Add(tr);
                }

            }
            foreach (var trainee in Trainees)
            {
                var student = Students.Where(x => x.StudentId == trainee.StudentId).FirstOrDefault();
                if (student != null && !StudentTrainees.Contains(student))
                {
                    StudentTrainees.Add(student);
                }
            }
            foreach (var trainee in Trainees.Where(x => x.Attended))
            {
                var student = Students.Where(x => x.StudentId == trainee.StudentId).FirstOrDefault();
                if (student != null && !AttendedStudents.Contains(student))
                {
                    AttendedStudents.Add(student);
                    if (student.Gender == Gender.M)
                    {
                        maleAttendees += 1;
                    }
                    else
                    {
                        femaleAttendees += 1;
                    }
                }
            }

        }
        participants = StudentTrainees.Count();
        participantsAttended = AttendedStudents.Count();
        events = sportEvents.Count();
        Trainees.Clear();
        AttendedStudents.Clear();
        StudentTrainees.Clear();
    }
}