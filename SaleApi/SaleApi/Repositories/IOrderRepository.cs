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
        //int SaveChanges(Order entity);
        bool AddOrderViewModel(OrderViewModel orderModel, string userId);
        bool AddOrderDetails(OrderViewModel orderModel, int orderId);
        Order SaveChanges(Order entity);
    }
}
