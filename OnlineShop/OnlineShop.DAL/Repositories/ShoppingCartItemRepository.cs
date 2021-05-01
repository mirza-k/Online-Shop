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
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper _mapper;

        public ShoppingCartItemRepository(OnlineShopContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Delete(Guid productId, Guid userId)
        {
            var shoppingCart = await _context.ShoppingCartItems.FirstOrDefaultAsync(x => x.ProductId == productId && x.UserId == userId);
            if (shoppingCart != null)
                _context.ShoppingCartItems.Remove(shoppingCart);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShoppingCartItemDTO>> GetByUserId(Guid id)
        {
            if (id == null || id == Guid.Empty)
                throw new NotImplementedException();

            return await _context.ShoppingCartItems
                .Where(x => x.UserId == id)
                .Include(x => x.Product).ThenInclude(x => x.Color)
                .Include(x => x.Product).ThenInclude(x => x.SubCategory)
                .Include(x => x.User)
                .Select(x => _mapper.Map<ShoppingCartItemDTO>(x)).ToListAsync();
        }

        public async Task<ShoppingCartItemDTO> Post(ShoppingCartItemDTO input)
        {
            var result = _context.ShoppingCartItems.FirstOrDefault(x => x.ProductId == input.ProductId && x.UserId == input.UserId);
            //product is not added to cart
            if (result == null)
            {
                ShoppingCartItem model = _mapper.Map<ShoppingCartItem>(input);
                _context.ShoppingCartItems.Add(model);
                await _context.SaveChangesAsync();
                return _mapper.Map<ShoppingCartItemDTO>(model);
            }
            //product already exists in cart
            return null;
        }

        public async Task<int> Update(ShoppingCartItemDTO obj)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == obj.ProductId);
            if (obj.Quantity > 1 && obj.Quantity < product.StockQuantity)
            {
                var model = _context.ShoppingCartItems.FirstOrDefault(x => x.ProductId == obj.ProductId && x.UserId == obj.UserId);
                model.ProductPrice = obj.ProductPrice;
                model.Quantity = obj.Quantity;
                model.TotalPrice = obj.TotalPrice;
                _context.ShoppingCartItems.Update(model);
            }

            return await _context.SaveChangesAsync();
        }
    }
}
