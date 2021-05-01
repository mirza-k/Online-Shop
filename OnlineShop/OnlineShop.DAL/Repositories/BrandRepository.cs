using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper mapper;

        public BrandRepository(OnlineShopContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<BrandDTO>> Get()
        {
            return await _context.Brands.Select(x => mapper.Map<BrandDTO>(x)).ToListAsync();
        }
    }
}
