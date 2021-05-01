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
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartItemService _shoppingCartService;

        public ShoppingCartItemController(IShoppingCartItemService shoppingCartItemService)
        {
            this._shoppingCartService = shoppingCartItemService;
        }

        [HttpPost]
        public async Task<ShoppingCartItemDTO> Post([FromBody] ShoppingCartItemDTO input)
        {
         return await _shoppingCartService.Post(input);
        }

        [Route("/api/ShoppingCartItem/User/{id}")]
        [HttpGet]
        public async Task<IEnumerable<ShoppingCartItemDTO>> GetByUserId(Guid id)
        {
            if (id == null || id == Guid.Empty)
                throw new ArgumentException("Guid is not valid");
            return await _shoppingCartService.GetByUserId(id);
        }

        [HttpDelete("{productId},{userId}")]
        public async Task<int> Delete(Guid productId, Guid userId)
        {
            if (productId == null || userId == Guid.Empty || productId == null || productId == Guid.Empty)
                throw new ArgumentException("Guid is not valid");

            return await _shoppingCartService.Delete(productId, userId);
        }

        [HttpPut]
        public async Task<int> Update([FromBody] ShoppingCartItemDTO obj)
        {
            return await _shoppingCartService.Update(obj);
        }
    }
}
