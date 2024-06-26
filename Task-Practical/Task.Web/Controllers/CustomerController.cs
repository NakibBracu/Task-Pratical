﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Task.Web.Models;
using Task.Web.Models.DTO;
using Task.Web.Services;

namespace Task.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMeetingMasterService _meetingMasterService;
        private readonly IPSService _pSService;

        private IList<ProductServiceRequest> collectedProductsOrServices = new List<ProductServiceRequest>();
        public CustomerController(ICustomerService customerService, IMeetingMasterService meetingMasterService, IPSService pSService)
        {
            _customerService = customerService;
            _meetingMasterService = meetingMasterService;
            _pSService = pSService;
        }
        public IActionResult Index()
        {
            var model = new MeetingCreateDTO(); // Initialize a new MeetingMaster object
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
            await _meetingMasterService.AddMeetingDetailsAsync(meetingDetails);
            return RedirectToAction("Index", "Home");
        }


       
        public async Task<IActionResult> GetProductorServices()
        {
             List<Tuple<Guid,string,int>> result = await _pSService.GetProductsOrServices();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddSingleProductOrService([FromBody] ProductServiceRequest request)
        {
            //// Assuming ProductServiceRequest has properties for CustomerId and ProductorServiceId
            //var customerId = request.CustomerId;
            //var productorServiceId = request.ProductorServiceId;
            //var quantity = request.Quantity;
            //var unit = request.Unit;
            // Adding the data to Meeting_Minutes_Details_Tbl
            await _pSService.AddProductorService(request);
            collectedProductsOrServices.Add(request);

            return Ok(new { success = true, message = "Product or service added successfully" });
        }

    }
}
