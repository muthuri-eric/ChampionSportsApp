using ChampionsDbHelper.DataAccess;
using ChampionsDbHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Data;
public class SubjectData : ISubjectData
{
    private readonly ISqlDataAccess _db;

    public SubjectData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Subject>> GetAllSubjectData()
    {
        return await _db.FetchData<Subject, dynamic>("select * from dbo.subject");
    }
    public async Task<IEnumerable<Subject>> GetSubjectById(int id)
    {
        return await _db.FetchData<Subject, dynamic>($"select * from dbo.subject where Id = {id}");
    }
}
