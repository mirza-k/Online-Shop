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
    public class ShoeSizesRepository : IShoeSizesRepository
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper _mapper;

        public ShoeSizesRepository(OnlineShopContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public IEnumerable<ShoeSizesDto> Get()
        {
            return _context.ShoesSizes.AsNoTracking().Select(x => _mapper.Map<ShoeSizesDto>(x)).ToList();
        }

        public async Task<ShoeSizesDto> GetById(int id)
        {
            return await _context.ShoesSizes.Where(x => x.ShoesSizeId == id).Select(x=>_mapper.Map<ShoeSizesDto>(x)).FirstOrDefaultAsync();
        }
    }
}
