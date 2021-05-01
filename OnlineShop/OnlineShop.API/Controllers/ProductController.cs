using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.IServices;
using OnlineShop.DTOModels;
using OnlineShop.DTOModels.ProductQueries;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet("{currentPage},{numberOfItems}")]
        //[Route("/api/product?{currentPage}&{numberOfItems}")]
        public async Task<IEnumerable<ProductDTO>> Get(int currentPage, int numberOfItems)
        {
            return await _productService.Get(currentPage, numberOfItems);
        }

        [HttpGet]
        [Route("/api/product/popular/{limit}")]
        public IEnumerable<ProductDTO> GetMostPopular(int limit)
        {
            if (limit < 1)
                throw new ArgumentException("Limit must be greater than 1");
            return _productService.GetMostPopular(limit);
        }

        [HttpGet]
        [Route("/api/product/{id}")]
        public ProductDTO GetById(Guid id)
        {
            if (id == null || id == Guid.Empty)
                throw new ArgumentException("Guid is not valid.");
            return _productService.GetById(id);
        }

        [HttpPost]
        public async Task<int> Post([FromBody] ProductDTO input)
        {
            return await _productService.Post(input);
        }

        [HttpPut("{id}")]
        public async Task<int> Update(Guid id, [FromBody] ProductDTO input)
        {
            if (id == null | id == Guid.Empty)
                throw new ArgumentException("Id not valid");

            return await _productService.Update(id, input);
        }

        [HttpDelete("{id}")]
        public async Task<int> Delete(Guid id)
        {
            return await _productService.Delete(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetBySearch([FromQuery] ProductQueries queries)
        {
            return await _productService.GetBySearch(queries);
        }

        [HttpGet]
        [Route("/api/product/genderCategory/{id}")]
        public async Task<IEnumerable<ProductDTO>> GetByGenderCategory(int id)
        {
            return await _productService.GetByGenderCategory(id);
        }
    }
}
