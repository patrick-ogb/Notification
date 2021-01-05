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
    public class NotificationChannelRepository : INotificationChannelRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connString ="";
        public NotificationChannelRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connString = configuration.GetConnectionString("NotificationConnection");
        }
        public async Task<int> AddAsync(NotificationChannel entity)
        {
            int result = 0;
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    entity.DateCreated = DateTime.Now;
                    connection.Open();
                    result = await connection.ExecuteAsync("Sp_NotificationChannel_Insert",
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
            int result = 0;
            try
            {
                var sql = "Sp_NotificationChannel_Delete";
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

        public async Task<IReadOnlyList<NotificationChannel>> GetAllAsync()
        {
            var sql = "Sp_NotificationChannel_FetchAll";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var result = await connection.QueryAsync<NotificationChannel>(sql, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<NotificationChannel> GetByIdAsync(int id)
        {
            var sql = "Sp_NotificationChannel_FetchById";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<NotificationChannel>(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> UpdateAsync(NotificationChannel entity)
        {
            entity.DateCreated = DateTime.Now;
            var sql = "Sp_NotificationChannel_Update";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
