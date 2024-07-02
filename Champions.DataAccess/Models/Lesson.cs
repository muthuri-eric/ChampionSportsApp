using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Models;
public class Lesson
{
    public int LessonId { get; set; }
    public int GradeLevelId { get; set; }
    public int SubjectId { get; set; }
    public DateTime LessonDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}
