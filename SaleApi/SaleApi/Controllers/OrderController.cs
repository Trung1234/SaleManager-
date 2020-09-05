using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaleApi.Common;
using SaleApi.Log;
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
        private IHttpContextAccessor _httpContextAccessor;
        public OrderController(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager ,
            SaleManagerContext context, IOrderRepository repo)
        {
            _context = context;
            _repo = repo;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: api/Order
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {         
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            return _repo.GetOrders(userId);
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult PostOrder([FromBody] OrderViewModel orderModel)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;      
            try
            {
                bool result = _repo.CreateOrder(orderModel, userId);
            }
            catch(Exception ex)
            {
                Logger.LogError();
            }
            Logger.LogInfo();
            return NoContent();
        }

    }
}
