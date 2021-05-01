using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.IServices
{
    public interface ICityService
    {
        public Task<IEnumerable<CityDTO>> Get();
    }
}
