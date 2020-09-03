using SaleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleApi.ViewModel
{
    public class OrderViewModel
    {
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public decimal TotalPrice { set; get; }
        public OrderItem[] OrderDetails { set; get; }
    }
}
