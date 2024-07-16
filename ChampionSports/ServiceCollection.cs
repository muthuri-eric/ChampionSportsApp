using ChampionsDbHelper.Data;
using ChampionsDbHelper.DataAccess;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ChampionSports;

public static class ServiceCollection
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        builder.Services.AddSingleton<ISportEventData, SportEventData>();
        builder.Services.AddSingleton<IEquipmentData, EquipmentData>();
        builder.Services.AddSingleton<IEquipmentDetailData, EquipmentDetailData>();
        builder.Services.AddSingleton<IGradeLevelData, GradeLevelData>();
        builder.Services.AddSingleton<ISubjectData, SubjectData>();
        builder.Services.AddSingleton<ILessonData, LessonData>();
        builder.Services.AddSingleton<IStudentData, StudentData>();
        builder.Services.AddSingleton<ISportData, SportData>();
        builder.Services.AddSingleton<ITraineeData, TraineeData>();
        builder.Services.AddSingleton<ITrainerData, TrainerData>();        
        builder.Services.AddSingleton<IActivityData, ActivityData>();
    }
}
