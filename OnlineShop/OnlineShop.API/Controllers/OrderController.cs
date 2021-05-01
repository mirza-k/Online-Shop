using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.IServices;
using OnlineShop.DTOModels;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpPost]
        public Task<OrderDTO> Post([FromBody]OrderDTO input)
        {
            return _orderService.Post(input);
        }

        [HttpGet("{userId},{currentPage},{numberOfItems}")]
        public async Task<IEnumerable<OrderDTO>> Get(Guid userId, int currentPage, int numberOfItems)
        {
            return await _orderService.Get(userId, currentPage, numberOfItems);
        }

        [HttpGet("/count/{userId}")]
        public int GetCount(Guid userId)
        {
            return _orderService.GetCount(userId);
        }

    }
}
