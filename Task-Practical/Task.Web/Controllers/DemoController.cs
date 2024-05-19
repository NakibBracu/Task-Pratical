using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Web.Models.Dbcontext;

namespace Task.Web.Controllers
{
    public class DemoController : Controller
    {
        private readonly DbContextClass _dbContext;
        public DemoController(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var data = _dbContext.MeetingMasters.Include(x => x.Customer)
                    .Include(x => x.meetingProductorServices).ThenInclude(x => x.ProductorService).ToList();

            return Ok(data);
        }
    }
}
