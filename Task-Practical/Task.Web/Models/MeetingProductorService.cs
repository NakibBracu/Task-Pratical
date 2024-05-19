namespace Task.Web.Models
{
    public class MeetingProductorService
    {
        public Guid Id { get; set; }
        public Guid MeetingId { get; set; }
        public MeetingMaster MeetingMaster { get; set; }

        public Guid ProductorServiceId { get; set; }
        public ProductorService ProductorService { get; set; }

        public int Quantity { get; set; }
        
    }

}
