using ChampionsDbHelper.Models;

namespace ChampionsDbHelper.Data;
public interface ISubjectData
{
    Task<IEnumerable<Subject>> GetAllSubjectData();
    Task<IEnumerable<Subject>> GetSubjectById(int id);
}