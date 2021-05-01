using OnlineShop.BLL.IServices;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            this._subCategoryRepository = subCategoryRepository;
        }
        public async Task<IEnumerable<SubCategoryDTO>> Get()
        {
            return await _subCategoryRepository.Get();
        }

        public async Task<IEnumerable<SubCategoryDTO>> GetByCategory(int id)
        {
            return await _subCategoryRepository.GetByCategory(id);
        }
    }
}
