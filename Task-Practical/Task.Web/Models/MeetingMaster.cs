namespace Task.Web.Models
{
    public class MeetingMaster
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string MeetingPlace { get; set; }
        public string MeetingAgenda { get; set;}
        public string MeetingDiscussion { get; set;}
        public string AttendsFromClientSide { get; set;}
        public string AttendsFromHostSide { get;set;}
        public string MeetingDecision { get; set; }

        // Relationship with Customer
        public Guid CustomerId { get; set; }  // Foreign key
        public Customer Customer { get; set; } // Navigation property

        public IList<MeetingProductorService> meetingProductorServices { get; set; }
    }
}
