using System;
using System.Collections.Generic;

namespace Models
{
    public class Invoice
    {
        public Guid ExternalId { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public List<string> Obsevations { get; set; }
        public List<Item> Items { get; set; }
        public User User { get; set; }
    }
}