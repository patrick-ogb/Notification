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
    public class EmailAlertRepository : IEmailAlertRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connString = "";
        public EmailAlertRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connString = configuration.GetConnectionString("NotificationConnection");
        }
        public async Task<int> AddAsync(EmailAlert entity)
        {
            int result = 0;
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    entity.DateCreated = DateTime.Now;
                    entity.DateProcessed = DateTime.Now;
                    connection.Open();
                    result = await connection.ExecuteAsync("Sp_EmailAlert_Insert",
                      new
                      {
                          entity.Email,
                          entity.Reeson,
                          entity.Status,
                          entity.Message,
                          entity.Subject,
                          entity.UserType,
                          entity.IsActive,
                          entity.Sendtries,
                          entity.CreatedBy,
                          entity.DateCreated,
                          entity.ReceiverName,
                          entity.DateProcessed,
                          entity.BackOfficeUser_SubscriberUser,
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
                    result = await connection.ExecuteAsync("Sp_EmailAlert_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return result;
            }
        }

        public async Task<IReadOnlyList<EmailAlert>> GetAllAsync()
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var results = await connection.QueryAsync<EmailAlert>("Sp_EmailAlert_FetchAll", commandType: CommandType.StoredProcedure);
                return results.AsList();
            }
        }

        public async Task<EmailAlert> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<EmailAlert>("Sp_EmailAlert_FetchById", new { Id = id }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        
        public async Task<int> UpdateAsync(EmailAlert entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateProcessed = DateTime.Now;
            entity.CreatedBy = "System";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync("Sp_EmailAlert_Update",
                    new
                    {
                        entity.Id,
                        entity.Email,
                        entity.Reeson,
                        entity.Status,
                        entity.Message,
                        entity.Subject,
                        entity.UserType,
                        entity.IsActive,
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
        }
    }
}
