using Microsoft.AspNetCore.Mvc;
using Task.Web.Models;
using Task.Web.Services;

namespace Task.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
           _customerService = customerService;
        }
        public IActionResult Index()
        {
            var model = new MeetingMaster(); // Initialize a new MeetingMaster object
            return View(model);
        }

        public async Task<IActionResult> GetCustomerNames(string customerType)
        {
            // Call your data access layer or service to retrieve customer names based on the customer type
            List<string> customerNames = new List<string>();

            // Populate customerNames based on the customerType
            if (customerType == "Corporate")
            {
                var corporateCustName = await _customerService.GetCorporateCustomersName();
                foreach (var c in corporateCustName) {
                    customerNames.Add(c);
                }
            }
            else if (customerType == "Individual")
            {
                var IndividualCustName = await _customerService.GetIndividualCustomersName();
                foreach (var c in IndividualCustName)
                {
                    customerNames.Add(c);
                }
            }

            // Return customer names as JSON
            return Json(customerNames);
        }
    }
}
