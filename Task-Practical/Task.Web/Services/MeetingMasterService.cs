using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task.Web.Models;
using Task.Web.Models.Dbcontext;
using System.Threading.Tasks; // Ensure to include this namespace

namespace Task.Web.Services
{
    public class MeetingMasterService : IMeetingMasterService
    {
        private readonly DbContextClass _dbContext;
        public MeetingMasterService(DbContextClass dbContextClass)
        {
            _dbContext = dbContextClass;
        }

        public async ValueTask AddMeetingDetailsAsync(MeetingMaster meetingdetails)
        {
            try
            {
                var parameter = new List<SqlParameter>();
                parameter.Add(new SqlParameter("@MeetingPlace", meetingdetails.MeetingPlace));
                parameter.Add(new SqlParameter("@MeetingAgenda", meetingdetails.MeetingAgenda));
                parameter.Add(new SqlParameter("@MeetingDiscussion", meetingdetails.MeetingDiscussion));
                parameter.Add(new SqlParameter("@AttendsFromClientSide", meetingdetails.AttendsFromClientSide));
                parameter.Add(new SqlParameter("@AttendsFromHostSide", meetingdetails.AttendsFromHostSide));
                parameter.Add(new SqlParameter("@MeetingDecision", meetingdetails.MeetingDecision));
                parameter.Add(new SqlParameter("@CustomerId", meetingdetails.CustomerId));
                parameter.Add(new SqlParameter("@Date", meetingdetails.Date));
                parameter.Add(new SqlParameter("@Time", meetingdetails.Time));

                await _dbContext.Database.ExecuteSqlRawAsync(@"exec AddMeetingDetails @MeetingPlace, @MeetingAgenda,@MeetingDiscussion,@AttendsFromClientSide,@AttendsFromHostSide,@MeetingDecision,@CustomerId,@Date,@Time", parameter.ToArray());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


    }
}
