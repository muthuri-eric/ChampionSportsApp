using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Models;
public class EquipmentDetail
{
    public int EquipmentDetailId { get; set; }
    public int EquipmentId { get; set; }
    public int TraineeId { get; set; }
    public int SportEventId { get; set; }  
    public string SerialNumber { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.Now;
    public DateTime ReturnDate { get; set; }
    public bool Status { get; set; } = false;
}
