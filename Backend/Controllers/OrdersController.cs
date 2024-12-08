using System.Collections.Generic;
using Backend.Features.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public void AddOrder([FromBody] Order order)
        {
            _orderService.AddOrder(order);
        }

    }
}
