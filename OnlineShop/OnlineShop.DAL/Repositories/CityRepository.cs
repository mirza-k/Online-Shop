using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Helpers;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repositories
{
   public class CityRepository : ICityRepository
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper _mapper;

        public CityRepository(OnlineShopContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<CityDTO>> Get()
        {
            return await _context.Cities.Select(x => _mapper.Map<CityDTO>(x)).ToListAsync(); ;
        }
    }
}
