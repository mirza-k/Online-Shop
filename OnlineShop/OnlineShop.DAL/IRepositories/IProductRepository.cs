using OnlineShop.DTOModels;
using OnlineShop.DTOModels.ProductQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.IRepositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductDTO>> Get(int currentPage, int numberOfItems);
        public IEnumerable<ProductDTO> GetMostPopular(int limit);
        public ProductDTO GetById(Guid id);
        public void ReduceQuantity(Guid productId, int quantity);
        public Task<int> Post(ProductDTO input);
        public Task<int> Update(Guid id, ProductDTO input);
        public Task<int> Delete(Guid id);
        public Task<IEnumerable<ProductDTO>> GetBySearch(ProductQueries queries);
        public Task<IEnumerable<ProductDTO>> GetByGenderCategory(int id);

    }
}
