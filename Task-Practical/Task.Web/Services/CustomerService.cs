using Microsoft.EntityFrameworkCore;
using System.Data;
using Task.Web.Models;
using Task.Web.Models.Dbcontext;
using Task.Web.Models.DTO;


namespace Task.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DbContextClass _dbContext;
        public CustomerService(DbContextClass dbContextClass)
        {
            _dbContext = dbContextClass;
        }

        public async Task<List<string>> GetCorporateCustomersName()
        {
            var customerNames = new List<string>();

            try
            {
                var connection = _dbContext.Database.GetDbConnection();
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "GetCorporateCustomerName";
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            customerNames.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                await _dbContext.Database.CloseConnectionAsync();
            }

            return customerNames;
        }



        public async Task<List<string>> GetIndividualCustomersName()
        {
            var customerNames = new List<string>();

            try
            {
                var connection = _dbContext.Database.GetDbConnection();
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "GetIndividualCustomerName";
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            customerNames.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                await _dbContext.Database.CloseConnectionAsync();
            }

            return customerNames;
        }

    }
}
