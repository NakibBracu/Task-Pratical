
namespace Task.Web.Services
{
    public interface ICustomerService
    {
        Task<List<string>> GetCorporateCustomersName();
        Task<List<string>> GetIndividualCustomersName();
    }
}