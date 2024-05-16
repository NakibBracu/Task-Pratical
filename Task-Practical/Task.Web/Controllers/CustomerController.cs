using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
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
            List<Tuple<Guid, string>> customerNames;

            // Populate customerNames based on the customerType
            if (customerType == "Corporate")
            {
                customerNames = await _customerService.GetCorporateCustomersName();
            }
            else if (customerType == "Individual")
            {
                customerNames = await _customerService.GetIndividualCustomersName();
            }
            else
            {
                // Handle invalid customer type
                return BadRequest("Invalid customer type.");
            }

            // Convert customerNames to a format suitable for JSON serialization
            var jsonData = customerNames.Select(customer => new[] { customer.Item1.ToString(), customer.Item2 });

            // Return customer names as JSON
            return Json(jsonData);
        }

        public async Task<IActionResult> SaveMeetingDetails(MeetingMaster meetingDetails) { 
            
            return View(meetingDetails);
        }

    }
}
