using OnlineShop.BLL.IServices;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            this._colorRepository = colorRepository;
        }
        public Task<IEnumerable<ColorDTO>> Get()
        {
            return _colorRepository.Get();
        }
    }
}
