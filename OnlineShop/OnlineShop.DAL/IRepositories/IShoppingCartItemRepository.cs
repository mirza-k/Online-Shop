using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.IRepositories
{
    public interface IShoppingCartItemRepository
    {
        public Task<ShoppingCartItemDTO> Post(ShoppingCartItemDTO input);
        public Task<int> Delete(Guid productId, Guid userId);
        public Task<int> Update(ShoppingCartItemDTO obj);
        public Task<IEnumerable<ShoppingCartItemDTO>> GetByUserId(Guid id);

    }
}
