using ChampionsDbHelper.DataAccess;
using ChampionsDbHelper.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsDbHelper.Data;
public class EquipmentDetailData : IEquipmentDetailData
{
    private readonly ISqlDataAccess _db;
    private readonly IConfiguration _config;

    public EquipmentDetailData(ISqlDataAccess db, IConfiguration config)
    {
        _db = db;
        _config = config;
    }
    public async Task<IEnumerable<EquipmentDetail>> GetEquipmentDetailByTraineeIdAsync(int sportEventId, int participantId)
    {
        return await _db.FetchData<EquipmentDetail, dynamic>($"select * from dbo.EquipmentDetail where SportEventId = {sportEventId}" +
            $"and TraineeId = {participantId}");
    }
    public async Task<EquipmentDetail?> GetEquipmentDetailById(int id)
    {
        var results = await _db.FetchData<EquipmentDetail, dynamic>($"select * from dbo.EquipmentDetail where EquipmentDetailId = {id}");
        return results.FirstOrDefault();
    }
    public async Task InsertEquipmentDetail(EquipmentDetail detail, Equipment equipment, string connectiodId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectiodId));
        connection.Open();
        using var transaction = connection.BeginTransaction();
        try
        {
            await connection.ExecuteAsync("spEquipmentDetailInsert", new
            {
                detail.EquipmentId,
                detail.TraineeId,
                detail.SportEventId,
                detail.SerialNumber,
                detail.IssueDate,
                detail.Status,
            }, transaction, commandType: CommandType.StoredProcedure);
            await connection.ExecuteAsync("spEquipmentUpdate", new
            {
                equipment.EquipmentId,
                equipment.SportId,
                equipment.Description,
                equipment.StockCount
            }, transaction, commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw;
        }
        transaction.Commit();
        connection.Close();
    }
    public async Task UpdateEquipmentDetail(EquipmentDetail detail)
    {
        await _db.UpdateDataAsync("spEquipmentDetailUpdate", new
        {
            detail.EquipmentDetailId,
            detail.TraineeId,
            detail.SportEventId,
            detail.EquipmentId,
            detail.SerialNumber,
            detail.ReturnDate,
            detail.IssueDate,
            detail.Status,
        });
    }
}
