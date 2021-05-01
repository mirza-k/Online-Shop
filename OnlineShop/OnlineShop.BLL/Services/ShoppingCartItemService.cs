using OnlineShop.BLL.IServices;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private readonly IShoppingCartItemRepository _shoppingCartRepos;

        public ShoppingCartItemService(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            this._shoppingCartRepos = shoppingCartItemRepository;
        }

        public async Task<int> Delete(Guid productId, Guid userId)
        {
            return await _shoppingCartRepos.Delete(productId, userId);
        }

        public async Task<IEnumerable<ShoppingCartItemDTO>> GetByUserId(Guid id)
        {
            return await _shoppingCartRepos.GetByUserId(id);
        }

        public async Task<ShoppingCartItemDTO> Post(ShoppingCartItemDTO input)
        {
            return await _shoppingCartRepos.Post(input);
        }

        public async Task<int> Update(ShoppingCartItemDTO obj)
        {
            return await _shoppingCartRepos.Update(obj);
        }
    }
}
