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
    public class SMSAlertRepository : ISMSAlertRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connString = "";
        public SMSAlertRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connString = configuration.GetConnectionString("NotificationConnection");
        }
        public async Task<int> AddAsync(SMSAlert entity)
        {
            int result = 0;
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    entity.DateCreated = DateTime.Now;
                    entity.DateProcessed = DateTime.Now;
                    connection.Open();
                    result = await connection.ExecuteAsync("Sp_SMSAlert_Insert",
                      new
                      {
                          entity.MobileNo,
                          entity.Subject,
                          entity.Message,
                          entity.ReceiverName,
                          entity.Reeson,
                          entity.Status,
                          entity.UserType,
                          entity.Sendtries,
                          entity.IsActive,
                          entity.BackOfficeUser_SubscriberUser,
                          entity.CreatedBy,
                          entity.DateCreated,
                          entity.DateProcessed,
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
                    result = await connection.ExecuteAsync("Sp_SMSAlert_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return result;
            }
        }

        public async Task<IReadOnlyList<SMSAlert>> GetAllAsync()
        {
            using (var connection = new SqlConnection(connString))
            {
                IEnumerable<SMSAlert> results = null;
                try
                {
                    connection.Open();
                    results = await connection.QueryAsync<SMSAlert>("Sp_SMSAlert_FetchAll", commandType: CommandType.StoredProcedure);
                    return results.AsList();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return results.AsList();
                }
            }
        }

        public async Task<SMSAlert> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(connString))
            {
                SMSAlert result = null;
                try
                {
                    connection.Open();
                    result = await connection.QuerySingleOrDefaultAsync<SMSAlert>("Sp_SMSAlert_FetchById", new { Id = id }, commandType: CommandType.StoredProcedure);
                    return result;
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return result;
                }
            }
        }

        public async Task<int> UpdateAsync(SMSAlert entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateProcessed = DateTime.Now;
            entity.CreatedBy = "System";
            using (var connection = new SqlConnection(connString))
            {
                int result = 0;
                connection.Open(); try
                {

                    result = await connection.ExecuteAsync("Sp_SMSAlert_Update",
                        new
                        {
                            entity.Id,
                            entity.Reeson,
                            entity.Status,
                            entity.Subject,
                            entity.Message,
                            entity.UserType,
                            entity.IsActive,
                            entity.MobileNo,
                            entity.Sendtries,
                            entity.CreatedBy,
                            entity.DateCreated,
                            entity.ReceiverName,
                            entity.DateProcessed,
                            entity.BackOfficeUser_SubscriberUser,
                        }
                        , commandType: CommandType.StoredProcedure);
                    return result;
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return result;
                }
            }
        }
    }
}
