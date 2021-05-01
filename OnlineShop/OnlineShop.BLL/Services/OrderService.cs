using OnlineShop.BLL.IServices;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DAL.Repositories;
using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDTO>> Get(Guid userId, int currentPage, int numberOfPages)
        {
            return await _orderRepository.Get(userId, currentPage, numberOfPages);
        }

        public int GetCount(Guid userId)
        {
            return _orderRepository.GetCount(userId);
        }

        public Task<OrderDTO> Post(OrderDTO input)
        {
            return _orderRepository.Post(input);
        }
    }
}
