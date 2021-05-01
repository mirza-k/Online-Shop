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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            return await _categoryRepository.Get();
        }
    }
}
