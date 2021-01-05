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
    public class ActivityLogRepository : IActivityLogRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connString = "";
        public ActivityLogRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connString = configuration.GetConnectionString("NotificationConnection");
        }
        public async Task<int> AddAsync(ActivityLog entity)
        {
            int result = 0;
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    entity.DateCreated = DateTime.Now;
                    connection.Open();
                    result = await connection.ExecuteAsync("Sp_ActivityLog_Insert",
                      new
                      {
                          entity.ApplicationName,
                          entity.Url,
                          entity.ActivityTyp_Request_Response,
                          entity.Data,
                          entity.DateCreated,
                          entity.UserName,
                          entity.IPAddress,
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
            int result = 0;
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    result = await connection.ExecuteAsync("Sp_ActivityLog_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return result;
            }
        }

        public async Task<IReadOnlyList<ActivityLog>> GetAllAsync()
        {
            using (var connection = new SqlConnection(connString))
            {
                IEnumerable<ActivityLog> results = null;
                try
                {
                    connection.Open();
                    results = await connection.QueryAsync<ActivityLog>("Sp_ActivityLog_FetchAll", commandType: CommandType.StoredProcedure);
                    return results.AsList();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return results.AsList();
                }
                
            }
        }

        public async Task<ActivityLog> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(connString))
            {
                ActivityLog result = null;
                try
                {
                    connection.Open();
                   result = await connection.QuerySingleOrDefaultAsync<ActivityLog>("Sp_ActivityLog_FetchById", new { Id = id }, commandType: CommandType.StoredProcedure);
                    return result;
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return result;
                }
            }
        }

        public async Task<int> UpdateAsync(ActivityLog entity)
        {
            entity.DateCreated = DateTime.Now;
            using (var connection = new SqlConnection(connString))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    result = await connection.ExecuteAsync("Sp_ActivityLog_Update",
                     entity,
                     commandType: CommandType.StoredProcedure);
                    return result;
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return result;
                }
            }
                
        }

        public async Task<IReadOnlyList<ActivityLog>> FetchByApplicationName(string ApplicationName)
        {
            using (var connection = new SqlConnection(connString))
            {
                IEnumerable<ActivityLog> results = null;
                try
                {
                    connection.Open();
                    results = await connection.QueryAsync<ActivityLog>("Sp_ActivityLog_FetchByApplicationName",
                        new
                        {
                            ApplicationName = ApplicationName
                        }
                        , commandType: CommandType.StoredProcedure);
                    return results.AsList();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return results.AsList();
                }
            }
        }

        public async Task<List<ActivityLogDateRange>> FetchByDateRange(ActivityLogDateRange dateRangeEntity)
        {
            using (var connection = new SqlConnection(connString))
            {
                IEnumerable<ActivityLogDateRange> results = null;
                try
                {
                    connection.Open();
                    results = await connection.QueryAsync<ActivityLogDateRange>("Sp_ActivityLog_FetchByDateRange",
                        new
                        {
                            StartDate = dateRangeEntity.StartDate,
                            EndDate = dateRangeEntity.EndDate,
                        }
                        , commandType: CommandType.StoredProcedure);
                    return results.AsList();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return results.AsList();
                }
            }
        }

        public async Task<IReadOnlyList<ActivityLog>> FetchByUrl(string Url)
        {
            using (var connection = new SqlConnection(connString))
            {
                IEnumerable<ActivityLog> results = null;
                try
                {
                    connection.Open();
                    results = await connection.QueryAsync<ActivityLog>("Sp_ActivityLog_FetchByUrl",
                        new
                        {
                            Url = Url
                        }
                        , commandType: CommandType.StoredProcedure);
                    return results.AsList();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return results.AsList();
                }
            }
        }
    }
}
