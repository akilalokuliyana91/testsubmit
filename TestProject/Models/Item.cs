using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public string Qty { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}