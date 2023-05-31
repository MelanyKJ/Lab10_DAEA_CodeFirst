using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public DateTime CreatedOn { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public List<Detail> Details { get; set; }

    }
}