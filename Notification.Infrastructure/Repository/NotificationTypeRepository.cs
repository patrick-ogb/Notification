using Dapper;
using Microsoft.Extensions.Configuration;
using Notification.Application.Interfaces;
using Notification.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Notification.Infrastructure.Repository
{
    public class NotificationTypeRepository : INotificationTypeRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connString = "";
        public NotificationTypeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connString = configuration.GetConnectionString("NotificationConnection");
        }
        public async Task<int> AddAsync(NotificationType entity)
        {
            int result = 0;
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    entity.DateCreated = DateTime.Now;
                    connection.Open();
                    result = await connection.ExecuteAsync("Sp_NotificationType_Insert",
                      new
                      {
                          entity.Name,
                          entity.Description,
                          entity.CreatedBy,
                          entity.DateCreated,
                      },
                      commandType: CommandType.StoredProcedure); ;
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
            var sql = "Sp_NotificationType_Delete";
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

        public async Task<IReadOnlyList<NotificationType>> GetAllAsync()
        {
            var sql = "Sp_NotificationType_FetchAll";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var results = await connection.QueryAsync<NotificationType>(sql, commandType: CommandType.StoredProcedure);
                return results.AsList();
            }
        }

        public async Task<NotificationType> GetByIdAsync(int id)
        {
            var sql = "Sp_NotificationType_FetchById";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<NotificationType>(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> UpdateAsync(NotificationType entity)
        {
            entity.DateCreated = DateTime.Now;
            var sql = "Sp_NotificationType_Update";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
