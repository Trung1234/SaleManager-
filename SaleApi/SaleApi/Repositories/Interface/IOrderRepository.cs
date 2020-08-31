using SaleApi.Models;
using SaleApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleApi.Repositories
{
    public interface IOrderRepository 
    {
        bool CreateOrder(OrderViewModel orderModel, string userId);
        bool AddOrderDetails(OrderViewModel orderModel, int orderId);
        Order SaveChanges(Order entity);
    }
}
