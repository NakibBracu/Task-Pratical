namespace Task.Web.Models.DTO
{
    public class ProductServiceRequest
    {
        public Guid CustomerId { get; set; }
       
        public IList<ProductDetails> ProductDetails { get; set; }
    }

    public class ProductDetails
    {
        public Guid ProductorServiceId { get; set; }
        public int Quantity { get; set; }
        public int Unit { get; set; }
    }
}
