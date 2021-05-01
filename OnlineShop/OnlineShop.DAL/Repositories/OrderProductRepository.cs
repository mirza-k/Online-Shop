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
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly IMapper _mapper;
        private readonly OnlineShopContext _context;
        private readonly IProductRepository _productRepository;

        public OrderProductRepository(IMapper mapper,OnlineShopContext context, IProductRepository productRepository)
        {
            this._mapper = mapper;
            this._context = context;
            this._productRepository = productRepository;
        }

        public async Task<IEnumerable<OrderProductDTO>> Get(int orderId)
        {
            return await _context.OrderProducts.Where(x => x.OrderId == orderId).Include(x=>x.Product).Select(x => _mapper.Map<OrderProductDTO>(x)).ToListAsync();
        }

        public async Task<int> Post(OrderProductDTO input)
        {
            var model = _mapper.Map<OrderProduct>(input);
            _context.OrderProducts.Add(model);
            _productRepository.ReduceQuantity(input.ProductId, Decimal.ToInt32(input.Quantity));

            return await _context.SaveChangesAsync();
        }
    }
}
