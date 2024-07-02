using ChampionsDbHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Models;
public class SportEvent
{
    public int SportEventId { get; set; }
    public int LessonId { get; set; }
    public int SportId { get; set; }
    public int TrainerId { get; set; }
    public string MatchDescription { get; set; }
    public string Location { get; set; }
    public DateTime EventDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public bool IsFullyAttended { get; set; }
    public List<Equipment> EquipmentsAllocated { get; set; }
    public List<Trainee> Participants { get; set; }
}
