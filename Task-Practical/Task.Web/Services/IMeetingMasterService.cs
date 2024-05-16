using Task.Web.Models;

namespace Task.Web.Services
{
    public interface IMeetingMasterService
    {
        ValueTask AddMeetingDetailsAsync(MeetingMaster meetingdetails);
    }
}