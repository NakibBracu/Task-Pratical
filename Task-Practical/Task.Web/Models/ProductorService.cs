namespace Task.Web.Models
{
    public class ProductorService
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public List<Customer>? customers { get; set; }
       
    }
}
