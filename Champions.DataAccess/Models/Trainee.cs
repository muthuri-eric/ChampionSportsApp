using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Models;
public class Trainee
{
    public int TraineeId { get; set; }
    public int StudentId { get; set; }
    public int SportEventId { get; set; }
    public bool Accepted { get; set; }
    public bool Attended { get; set; } = false;
    public List<Activity> Activities { get; set; } 
    public List<EquipmentDetail> Equipments { get; set; }

}
