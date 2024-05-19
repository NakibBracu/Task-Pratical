using Microsoft.AspNetCore.Mvc;
using Task.Web.Models.DTO;

namespace Task.Web.Controllers
{
    public class MeetingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMeeting(MeetingCreateDTO meetingCreateDTO) {
            return Ok(meetingCreateDTO);
        }
    }
}
