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

        public OrderController(SaleManagerContext context, IDataRepository<Order> repo)
        {
            _context = context;
            _repo = repo;
        }
        // GET: api/Products
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return _context.Order.OrderByDescending(p => p.ID);
        }
        // POST: api/Order
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] OrderViewModel order)
        {
            OrderViewModel test = order;

           //repo.Add(order);
            //r save = await _repo.SaveAsync(order);

            return NoContent();
        }

    }
}
