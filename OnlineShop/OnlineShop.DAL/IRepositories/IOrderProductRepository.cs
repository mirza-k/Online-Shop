using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.IRepositories
{
    public interface IOrderProductRepository
    {
        public Task<int> Post(OrderProductDTO input);
        public Task<IEnumerable<OrderProductDTO>> Get(int orderId);
    }
}
