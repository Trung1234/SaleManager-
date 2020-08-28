using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaleApi.Models;
using SaleApi.Repositories;
using SaleApi.ViewModel;

namespace SaleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly SaleManagerContext _context;
        private readonly IDataRepository<Order> _repo;
        private readonly IDataRepository<OrderDetail> _repoOrderDetail;
        private UserManager<ApplicationUser> _userManager;
        public OrderController(UserManager<ApplicationUser> userManager ,
            SaleManagerContext context, IDataRepository<Order> repo, IDataRepository<OrderDetail> repoOrderDetail)
        {
            _context = context;
            _repo = repo;
            _userManager = userManager;
            _repoOrderDetail = repoOrderDetail;
        }
        // GET: api/Products
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return _context.Order.OrderByDescending(p => p.ID);
        }
        // POST: api/Order
        [HttpPost]
        public IActionResult PostOrder([FromBody] OrderViewModel orderModel)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
        
            try
            {
                Order order = new Order
                {
                    OrderDate = DateTime.Now,
                    ShipAddress = "Ha Noi",
                    ShipEmail = orderModel.ShipEmail,
                    ShipName = orderModel.ShipName,
                    ShipPhoneNumber = "12324214",
                    UserId = userId
                };
                _repo.Add(order);
                Order newOrder = _repo.SaveChanges(order);
                foreach(var orderDetail in orderModel.OrderDetails)
                {
                    OrderDetail detail = new OrderDetail
                    {
                        ColorId = 1,
                        Quantity = orderDetail.Quantity,
                        Price = orderDetail.Product.Price* orderDetail.Quantity,
     
                        ProductID = orderDetail.Product.ID,
                        OrderID = newOrder.ID
                    };
                    _repoOrderDetail.Add(detail);
                    _repoOrderDetail.SaveChanges(detail);
                }
            }
            catch(Exception ex)
            {

            }
            return NoContent();
        }

    }
}
