using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.IRepositories
{
    public interface IShoeSizesRepository
    {
        public IEnumerable<ShoeSizesDto> Get();
        public Task<ShoeSizesDto> GetById(int id);
    }
}
