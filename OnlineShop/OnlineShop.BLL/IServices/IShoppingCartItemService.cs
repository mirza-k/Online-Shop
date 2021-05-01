using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.IServices
{
    public interface IShoppingCartItemService
    {
        public Task<ShoppingCartItemDTO> Post(ShoppingCartItemDTO input);
        public Task<int> Delete(Guid productId, Guid userId);
        public Task<IEnumerable<ShoppingCartItemDTO>> GetByUserId(Guid id);
        public Task<int> Update(ShoppingCartItemDTO obj);
    }
}
