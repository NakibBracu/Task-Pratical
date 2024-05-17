using Microsoft.EntityFrameworkCore;
using System.Data;
using Task.Web.Models.Dbcontext;

namespace Task.Web.Services
{
    public class PSService : IPSService
    {
        private readonly DbContextClass _dbContext;
        public PSService(DbContextClass dbContextClass)
        {
            _dbContext = dbContextClass;
        }

        public async Task<List<Tuple<Guid, string, int>>> GetProductsOrServices()
        {
            var customerNames = new List<Tuple<Guid, string, int>>();

            try
            {
                var connection = _dbContext.Database.GetDbConnection();
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "GetAvailable_Products_Or_Services";
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var id = reader.GetGuid(0);
                            var name = reader.GetString(1);
                            var unit = reader.GetInt32(2);
                            var tuple = Tuple.Create(id, name, unit);
                            customerNames.Add(tuple);
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
