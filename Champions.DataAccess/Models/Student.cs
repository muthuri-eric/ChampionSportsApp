using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Models;
public class Student
{
    public int StudentId { get; set; }
    public string Id { get; set; }
    public string StudentNumber { get; set; }
    public int GradeLevelId { get; set; }
    public Gender Gender { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
}
