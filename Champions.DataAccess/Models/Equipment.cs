using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Models;
public class Equipment
{
    public int EquipmentId { get; set; }
    public int SportId { get; set; }
    public string? Description { get; set; }
    public int StockCount { get; set; }
}
