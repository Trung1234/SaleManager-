﻿using SaleApi.Models;
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
        bool AddOrderItems(OrderViewModel orderModel, int orderId);
        List<Order> GetOrders(string userId);
        Order SaveChanges(Order entity);
    }
}
