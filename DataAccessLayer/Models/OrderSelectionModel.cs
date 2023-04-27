using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandHub.Map.Models
{
    public class OrderSelectionModel
    {
       
            public string customerReference { get; set; }
            public string orderReference { get; set; }
            public string customerName { get; set; }
            public DateTime orderDate { get; set; }
            public DateTime expectedShipDate { get; set; }
            public string orderStatus { get; set; }
            public string sku { get; set; }
            public object productDescription { get; set; }
            public string productType { get; set; }
            public int qty { get; set; }
            public string orderColor { get; set; }
        }

    }

