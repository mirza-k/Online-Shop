using OnlineShop.BLL.IServices;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class CityService:ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            this._cityRepository = cityRepository;
        }

        public async Task<IEnumerable<CityDTO>> Get()
        {
            return await _cityRepository.Get();
        }
    }
}
