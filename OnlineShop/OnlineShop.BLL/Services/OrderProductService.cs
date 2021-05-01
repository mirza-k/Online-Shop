using OnlineShop.BLL.IServices;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;

        public OrderProductService(IOrderProductRepository orderProductRepository)
        {
            this._orderProductRepository = orderProductRepository;
        }

        public async Task<IEnumerable<OrderProductDTO>> Get(int orderId)
        {
            return await _orderProductRepository.Get(orderId);
        }

        public Task<int> Post(OrderProductDTO input)
        {
            return _orderProductRepository.Post(input);
        }
    }
}
