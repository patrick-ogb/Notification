using Dapper;
using Microsoft.Extensions.Configuration;
using Notification.Application.Interfaces;
using Notification.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.Repository
{
    public class NotificationTemplateRepository : INotificationTemplateRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connString = "";
        public NotificationTemplateRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connString = configuration.GetConnectionString("NotificationConnection");
        }
        public async Task<int> AddAsync(NotificationTemplate entity)
        {
            int result = 0;
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    entity.DateCreated = DateTime.Now;
                    connection.Open();
                    result = await connection.ExecuteAsync("Sp_NotificationTemplate_Insert",
                      new
                      {
                          entity.Name,
                          entity.CreatedBy,
                          entity.DateCreated,
                          entity.Description,
                          entity.NotificationTypeId,
                          entity.NotificationChannelId,
                      },
                      commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "Sp_NotificationTemplate_Delete";
            int result = 0;
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    result = await connection.ExecuteAsync(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return result;
            }
        }

        public async Task<int> FetchByNotificationTypeId(int id)
        {
            var sql = "Sp_NotificationTemplate_FetchByNotificationTypeId";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var results = await connection.QuerySingleOrDefaultAsync(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        public async Task<int> FetchByNotificationChannelId(int id)
        {
            var sql = "Sp_NotificationTemplate_FetchByNotificationChannelId";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var results = await connection.QuerySingleOrDefaultAsync(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        public async Task<IReadOnlyList<NotificationTemplate>> GetAllAsync() 
        {
            var sql = "Sp_NotificationTemplate_FetchAll";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var results = await connection.QueryAsync<NotificationTemplate>(sql,commandType: CommandType.StoredProcedure);
                return results.AsList();
            }
        }

        public async Task<NotificationTemplate> GetByIdAsync(int id)
        {
            var sql = "Sp_NotificationTemplate_FetchById";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<NotificationTemplate>(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }


        public async Task<int> UpdateAsync(NotificationTemplate entity)
        {
            entity.DateCreated = DateTime.Now;
            var sql = "Sp_NotificationTemplate_Update";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, 
                    new
                    {
                        entity.Id,
                        entity.Name,
                        entity.CreatedBy,
                        entity.DateCreated,
                        entity.Description,
                        entity.NotificationTypeId,
                        entity.NotificationChannelId,
                    }
                    , commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
