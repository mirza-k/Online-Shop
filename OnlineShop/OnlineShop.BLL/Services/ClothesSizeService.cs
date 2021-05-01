using OnlineShop.BLL.IServices;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class ClothesSizeService:IClothesSizeService
    {
        private readonly IClothesSizeRepository _clothesSizeRepository;

        public ClothesSizeService(IClothesSizeRepository clothesSizeRepository)
        {
            this._clothesSizeRepository = clothesSizeRepository;
        }
        public async Task<IEnumerable<ClothesSizeDTO>> Get()
        {
            return await _clothesSizeRepository.Get();
        }

        public async Task<ClothesSizeDTO> GetById(int id)
        {
            return await _clothesSizeRepository.GetById(id);
        }
    }
}
