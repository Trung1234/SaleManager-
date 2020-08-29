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
        private readonly IOrderRepository _repo;
        private UserManager<ApplicationUser> _userManager;
        public OrderController(UserManager<ApplicationUser> userManager ,
            SaleManagerContext context, IOrderRepository repo)
        {
            _context = context;
            _repo = repo;
            _userManager = userManager;
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
                bool result = _repo.AddOrderViewModel(orderModel, userId);
            }
            catch(Exception ex)
            {

            }
            return NoContent();
        }

    }
}
