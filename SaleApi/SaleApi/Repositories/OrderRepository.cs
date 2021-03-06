﻿using Microsoft.EntityFrameworkCore;
using SaleApi.Models;
using SaleApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SaleManagerContext _context;

        public OrderRepository(SaleManagerContext context)
        {
            _context = context;
        }

       
        public bool CreateOrder(OrderViewModel orderModel, string userId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                int orderID = 0;
                Order order = new Order
                {
                    OrderDate = DateTime.Now,
                    ShipAddress = "Ha Noi",
                    ShipEmail = orderModel.ShipEmail,
                    ShipName = orderModel.ShipName,
                    ShipPhoneNumber = "12324214",
                    TotalPrice = orderModel.TotalPrice,
                    UserId = userId
                };
                _context.Add(order);
                SaveChanges(order);
                orderID = order.ID;
                if (orderID <= 0)
                {
                    transaction.Rollback();
                    return false;
                }
                if(!AddOrderItems(orderModel, orderID))
                {
                    transaction.Rollback();
                    return false;
                }
                transaction.Commit();
            }
            return true;
                
        }
        public bool AddOrderItems(OrderViewModel orderModel, int orderId)
        {
            try
            {
                if(orderModel.OrderDetails != null)
                {
                    foreach (var orderDetail in orderModel.OrderDetails)
                    {
                        OrderItem detail = new OrderItem
                        {
                            ColorId = 1,
                            Quantity = orderDetail.Quantity,
                            Price = orderDetail.Product.Price * orderDetail.Quantity,

                            ProductID = orderDetail.Product.ID,
                            OrderID = orderId
                        };
                        _context.Add(detail);
                        _context.SaveChanges();
                    }
                }              
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public Order SaveChanges(Order entity)
        {
            _context.SaveChanges();
            return entity;
        }

        public List<Order> GetOrders(string userId)
        {
            List<Order> result = new List<Order>();
            try
            {
                result = _context.Orders
                      .FromSql($"GetOrders {userId}")
                      .ToList();
            }
            catch (Exception ex)
            {
                return new List<Order>();
            }
            return result;
        }             
    }
}
