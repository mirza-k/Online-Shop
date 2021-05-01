using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using OnlineShop.DTOModels.ProductQueries;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper mapper;

        public ProductRepository(OnlineShopContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetByGenderCategory(int id)
        {
            return await _context.Products.Where(x => x.GenderCategoryId == id).Select(y=>mapper.Map<ProductDTO>(y)).ToListAsync();
        }

        public IEnumerable<ProductDTO> GetMostPopular(int limit)
        {
            return _context.Products.Where(x => x.IsVisible)
                                    .Include(x => x.Color)
                                    .Include(x => x.GenderCategory)
                                    .Include(x => x.Brand)
                                    .Include(x => x.SubCategory)
                                    .Where(x=>x.IsVisible == true)
                                    .OrderByDescending(x=>x.SoldQuantity)
                                    .Select(x => mapper.Map<ProductDTO>(x))
                                    .Take(limit)
                                    .ToList();
        }

        public ProductDTO GetById(Guid id)
        {
            return _context.Products.Where(x => x.ProductId == id)
                                    .Include(x => x.Color)
                                    .Include(x => x.GenderCategory)
                                    .Include(x => x.Brand)
                                    .Include(x => x.SubCategory)
                                    .Select(x => mapper.Map<ProductDTO>(x))
                                    .FirstOrDefault();
        }

        public async Task<int> Post(ProductDTO input)
        {
            Product model = mapper.Map<Product>(input);
            _context.Products.Add(model);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Guid id, ProductDTO input)
        {
            var model = mapper.Map<Product>(input);
            _context.Products.Update(model);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (result != null)
            {
                result.IsVisible = !result.IsVisible;
                _context.Products.Update(result);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDTO>> Get(int currentPage, int numberOfItems)
        {
            return await _context.Products.Include(x => x.Color)
                                    .Include(x => x.GenderCategory)
                                    .Include(x => x.Brand)
                                    .Include(x => x.SubCategory)
                                    .Skip((currentPage - 1) * numberOfItems)
                                    .Take(numberOfItems)
                                    .Select(x => mapper.Map<ProductDTO>(x))
                                    .ToListAsync();
        }

        private async Task<IEnumerable<ProductDTO>> SearchProducts(ProductQueries queries)
        {
            return await _context.Products
                             .Include(x => x.SubCategory)
                             .Where(x => queries.Name != null ? x.Name.ToLower().Contains(queries.Name.ToLower()) & x.SubCategory.CategoryId == queries.CategoryId
                                                      : x.SubCategory.CategoryId == queries.CategoryId)
                             .Select(x => mapper.Map<ProductDTO>(x)).ToListAsync();
        }

        public void ReduceQuantity(Guid productId,int quantity)
        {
            var model =_context.Products.FirstOrDefault(x => x.ProductId == productId);
            model.StockQuantity -= quantity;

            _context.Products.Update(model);
        }

        public async Task<IEnumerable<ProductDTO>> GetBySearch(ProductQueries queries)
        {
            if (queries.Search)
                return  await SearchProducts(queries);

            var query = _context.Products.AsQueryable();


            query = queries.CategoryId switch
            {
                1 => _context.Products.Where(x => x.SubCategory.CategoryId == 1),
                2 => _context.Products.Where(x => x.SubCategory.CategoryId == 2),
                _ => query
            };


            query = queries.Subcategory switch
            {
                "Nike Shoes" => query.Where(x => x.SubCategoryId == 1),
                "Tracksuit" => query.Where(x => x.SubCategoryId == 2),
                "Adidas Shoes" => query.Where(x => x.SubCategoryId == 3),
                "Puma Shoes" => query.Where(x => x.SubCategoryId == 4),
                "T-Shirt" => query.Where(x => x.SubCategoryId == 5),
                "Shorts" => query.Where(x => x.SubCategoryId == 6),
                "Hoodie" => query.Where(x => x.SubCategoryId == 7),
                "New Balance Shoes" => query.Where(x => x.SubCategoryId == 8),
                _ => query
            };

            query = queries.Brand switch
            {
                "Nike" => query.Where(x => x.BrandId == 1),
                "Adidas" => query.Where(x => x.BrandId == 2),
                "New Balance" => query.Where(x => x.BrandId == 3),
                _ => query
            };

            query = queries.Color switch
            {
                "White" => query.Where(x => x.ColorId == 1),
                "Red" => query.Where(x => x.ColorId == 2),
                "Blue" => query.Where(x => x.ColorId == 3),
                "Black" => query.Where(x => x.ColorId == 4),
                "Green" => query.Where(x => x.ColorId == 5),
                _ => query
            };

            query = queries.GenderCategory switch
            {
                "M" => query.Where(x => x.GenderCategoryId == 1),
                "F" => query.Where(x => x.GenderCategoryId == 2),
                "U" => query.Where(x => x.GenderCategoryId == 3),
                _ => query
            };

            return await query.Select(x => mapper.Map<ProductDTO>(x)).ToListAsync();

        }

        public async Task<IEnumerable<ProductDTO>> GetByFilters(ProductQueries queryFilters)
        {
            var query = _context.Products.AsQueryable();

            query = queryFilters.Subcategory switch
            {
                "Nike Shoes" => query.Where(x => x.SubCategoryId == 1),
                "Tracksuit" => query.Where(x => x.SubCategoryId == 2),
                "Adidas Shoes" => query.Where(x => x.SubCategoryId == 3),
                "Puma Shoes" => query.Where(x => x.SubCategoryId == 4),
                "T-Shirt" => query.Where(x => x.SubCategoryId == 5),
                "Shorts" => query.Where(x => x.SubCategoryId == 6),
                "Hoodie" => query.Where(x => x.SubCategoryId == 7),
                "New Balance Shoes" => query.Where(x => x.SubCategoryId == 8),
                _ => query
            };

            query = queryFilters.Brand switch
            {
                "Nike" => query.Where(x => x.BrandId == 1),
                "Adidas" => query.Where(x => x.BrandId == 2),
                "New Balance" => query.Where(x => x.BrandId == 3),
                _ => query
            };

            return await query.Select(x => mapper.Map<ProductDTO>(x)).ToListAsync();
        }

    }
}
