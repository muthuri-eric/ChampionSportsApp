using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Models;
public class Activity
{
    public int ActivityId { get; set; }
    public int TraineeId { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}
