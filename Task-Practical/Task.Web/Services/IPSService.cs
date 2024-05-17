
namespace Task.Web.Services
{
    public interface IPSService
    {
        Task<List<Tuple<Guid, string, int>>> GetProductsOrServices();
    }
}