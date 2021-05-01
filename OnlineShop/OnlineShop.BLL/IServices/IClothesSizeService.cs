using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.IServices
{
    public interface IClothesSizeService
    {
        public Task<IEnumerable<ClothesSizeDTO>> Get();
        public Task<ClothesSizeDTO> GetById(int id);

    }
}
