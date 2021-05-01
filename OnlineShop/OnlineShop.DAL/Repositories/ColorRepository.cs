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
    public class ColorRepository : IColorRepository
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper mapper;

        public ColorRepository(OnlineShopContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ColorDTO>> Get()
        {
            return await _context.Colors.Select(x => mapper.Map<ColorDTO>(x)).ToListAsync();
        }
    }
}
