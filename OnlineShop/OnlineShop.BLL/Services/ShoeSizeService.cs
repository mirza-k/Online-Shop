using OnlineShop.BLL.IServices;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class ShoeSizeService : IShoeSizeService
    {
        private readonly IShoeSizesRepository _repository;

        public ShoeSizeService(IShoeSizesRepository repository)
        {
            this._repository = repository;
        }
        public IEnumerable<ShoeSizesDto> Get()
        {
            return _repository.Get();
        }

        public async Task<ShoeSizesDto> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
