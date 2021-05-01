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
    public class OrderProductController : ControllerBase
    {
        private readonly IOrderProductService _orderProductService;

        public OrderProductController(IOrderProductService orderProductService)
        {
            this._orderProductService = orderProductService;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] OrderProductDTO input)
        {
            var result = await _orderProductService.Post(input);
            if (result == 1)
                return result;
            return 0;
        }

        [HttpGet("{orderId}")]
        public async Task<IEnumerable<OrderProductDTO>> Get(int orderId)
        {
            return await _orderProductService.Get(orderId);
        }
    }
}
