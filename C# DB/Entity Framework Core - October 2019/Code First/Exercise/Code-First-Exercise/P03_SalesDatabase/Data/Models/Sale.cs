namespace P03_SalesDatabase.Data.Models
{
    using System;

    public class Sale
    {
        public int SaleId { get; set; }

        public DateTime Date { get; set; }

        //Foreign Key
        public int ProductId { get; set; }
        //Navigation Property for navigation into the entities
        public Product Product { get; set; }

        //Foreign Key
        public int CustomerId { get; set; }
        //Navigation Property
        public Customer Customer { get; set; }

        //Foreign Key
        public int StoreId { get; set; }
        //Navigation Property
        public Store Store { get; set; }
    }
}