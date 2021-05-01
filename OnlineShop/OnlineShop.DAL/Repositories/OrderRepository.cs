using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;
        private readonly OnlineShopContext _context;

        public OrderRepository(IMapper mapper, OnlineShopContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<IEnumerable<OrderDTO>> Get(Guid userId, int currentPage, int numberOfPages)
        {
            var result = await _context.Orders
                .Where(x => x.UserId == userId)
                .Skip((currentPage - 1) * numberOfPages)
                .Take(numberOfPages)
                .Select(x => _mapper.Map<OrderDTO>(x))
                .ToListAsync();

            return result;
        }

        public int GetCount(Guid userId)
        {
            return _context.Orders.Where(x => x.UserId == userId).ToList().Count();
        }

        public async Task<OrderDTO> Post(OrderDTO input)
        {
            var model = _mapper.Map<Order>(input);
            _context.Orders.Add(model);
            var result = await _context.SaveChangesAsync();

            if (result == 1)
                return _mapper.Map<OrderDTO>(model);
            return null;
        }
    }
}
