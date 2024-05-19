
using Task.Web.Models.DTO;

namespace Task.Web.Services
{
    public interface IPSService
    {
        Task<List<Tuple<Guid, string, int>>> GetProductsOrServices();
        ValueTask AddProductorService(ProductServiceRequest ps);
    }
}