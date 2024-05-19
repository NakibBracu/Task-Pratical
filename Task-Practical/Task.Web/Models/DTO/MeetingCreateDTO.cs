namespace Task.Web.Models.DTO
{
    public class MeetingCreateDTO
    {
        public Guid CustomerId { get; set; }
        public DateTime Date {  get; set; }
        public DateTime Time { get; set; }
        public string MeetingPlace { get; set; }
        public string MeetingAgenda { get; set; }
        public string MeetingDiscussion { get; set; }
        public string AttendsFromClientSide { get; set; }
        public string AttendsFromHostSide { get; set; }
        public string MeetingDecision { get; set; }
        public IList<MeetingProductCreateDTO> meetingProductCreateDTOs { get; set; }

    }

    public class MeetingProductCreateDTO 
    { 
        public Guid ProductServiceId { get; set; }
        public int Quantity { get; set; }
    }
}
