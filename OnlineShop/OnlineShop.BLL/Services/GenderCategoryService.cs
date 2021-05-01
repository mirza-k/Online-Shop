using OnlineShop.BLL.IServices;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class GenderCategoryService : IGenderCategoryService
    {
        private readonly IGenderCategoryRepository _genderCategoryRepository;

        public GenderCategoryService(IGenderCategoryRepository genderCategoryRepository)
        {
            this._genderCategoryRepository = genderCategoryRepository;
        }
        public async Task<IEnumerable<GenderCategoryDTO>> Get()
        {
            return await _genderCategoryRepository.Get();
        }
    }
}
