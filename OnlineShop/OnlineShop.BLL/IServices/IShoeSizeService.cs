using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.IServices
{
    public interface IShoeSizeService
    {
        public IEnumerable<ShoeSizesDto> Get();
        public Task<ShoeSizesDto> GetById(int id);

    }
}
