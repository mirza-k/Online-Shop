using OnlineShop.BLL.IServices;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using OnlineShop.DTOModels.ProductQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<int> Delete(Guid id)
        {
            return await _productRepository.Delete(id);
        }

        public async Task<IEnumerable<ProductDTO>> Get(int currentPage, int numberOfItems)
        {
            return await _productRepository.Get(currentPage, numberOfItems);
        }

        public async Task<IEnumerable<ProductDTO>> GetByGenderCategory(int id)
        {
            return await _productRepository.GetByGenderCategory(id);
        }

        public ProductDTO GetById(Guid id)
        {
            return _productRepository.GetById(id);
        }

        public async Task<IEnumerable<ProductDTO>> GetBySearch(ProductQueries queries)
        {
            return await _productRepository.GetBySearch(queries);
        }

        public IEnumerable<ProductDTO> GetMostPopular(int limit)
        {
            return _productRepository.GetMostPopular(limit);
        }

        public Task<int> Post(ProductDTO input)
        {
            input.ProductId = Guid.NewGuid();
            input.DatePublished = DateTime.UtcNow;
            input.SoldQuantity = 0;
            input.IsVisible = true;
            input.IsEditing = false;

            return _productRepository.Post(input);
        }

        public async Task<int> Update(Guid id, ProductDTO input)
        {
            return await _productRepository.Update(id, input);
        }
    }
}
