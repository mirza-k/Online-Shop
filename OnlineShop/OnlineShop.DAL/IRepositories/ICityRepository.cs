using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.IRepositories
{
    public interface ICityRepository
    {
        public Task<IEnumerable<CityDTO>> Get();
    }
}
