
namespace Task.Web.Services
{
    public interface ICustomerService
    {
        Task<List<Tuple<Guid, string>>> GetCorporateCustomersName();
        Task<List<Tuple<Guid, string>>> GetIndividualCustomersName();
    }
}