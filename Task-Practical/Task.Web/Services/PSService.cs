using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Task.Web.Models.Dbcontext;
using Task.Web.Models.DTO;

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


        public async ValueTask AddProductorService(ProductServiceRequest ps) {
            try
            {
                var parameter = new List<SqlParameter>();

                //parameter.Add(new SqlParameter("@CustomerId", ps.CustomerId));
                //parameter.Add(new SqlParameter("@ProductorServiceId", ps.ProductorServiceId));
                //parameter.Add(new SqlParameter("@Quantity", ps.Quantity));
                
                await _dbContext.Database.ExecuteSqlRawAsync(@"exec Meeting_Minutes_Details_Save_SP @CustomerId, @ProductorServiceId,@Quantity", parameter.ToArray());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
