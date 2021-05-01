using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.IRepositories
{
    public interface IOrderRepository
    {
        public Task<OrderDTO> Post(OrderDTO input);
        public Task<IEnumerable<OrderDTO>> Get(Guid userId, int currentPage, int numberOfPages);
        public int GetCount(Guid userId);

    }
}
