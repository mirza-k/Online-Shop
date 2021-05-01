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
    public class ClothesSizeRepository : IClothesSizeRepository
    {
        private readonly IMapper mapper;
        private readonly OnlineShopContext _context;

        public ClothesSizeRepository(IMapper mapper, OnlineShopContext context)
        {
            this.mapper = mapper;
            this._context = context;
        }
        public async Task<IEnumerable<ClothesSizeDTO>> Get()
        {
            return await _context.ClothesSizes.Select(x=>mapper.Map<ClothesSizeDTO>(x)).ToListAsync();
        }

        public async Task<ClothesSizeDTO> GetById(int id)
        {
            return await _context.ClothesSizes.Where(x => x.ClothesSizeId == id).Select(x=>mapper.Map<ClothesSizeDTO>(x)).FirstOrDefaultAsync();
        }
    }
}
