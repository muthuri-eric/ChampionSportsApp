﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Models;
public class SearchModel
{
    public int Id { get; set; }
    public  DateTime FromDate { get; set; }
    public  DateTime ToDate { get; set; }
}
