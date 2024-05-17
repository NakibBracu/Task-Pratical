﻿namespace Task.Web.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ProductorService>? productorServices { get; set; }
    }
}
