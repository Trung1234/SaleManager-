using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public OrderController(SaleManagerContext context, IDataRepository<Order> repo, IDataRepository<OrderDetail> repoOrderDetail)
        {
            _context = context;
            _repo = repo;
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
        public async Task<IActionResult> PostOrder([FromBody] OrderViewModel orderModel)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach(var orderDetail in orderModel.OrderDetails)
            {
                _repoOrderDetail.Add(orderDetail);
                _repoOrderDetail.SaveAsync(orderDetail);
                orderDetails.Add(orderDetail);
            }
            Order order = new Order
            {
                OrderDate = DateTime.Now,
                ShipAddress = "Ha Noi",
                ShipEmail = orderModel.ShipEmail,
                ShipName = orderModel.ShipName,
                ShipPhoneNumber = "12324214",
                OrderDetails = orderDetails
            };
            _repo.Add(order);
            await _repo.SaveAsync(order);

            return NoContent();
        }

    }
}
