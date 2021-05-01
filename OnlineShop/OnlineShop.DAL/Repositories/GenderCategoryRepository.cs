using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repositories
{
    public class GenderCategoryRepository : IGenderCategoryRepository
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper mapper;

        public GenderCategoryRepository(OnlineShopContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<GenderCategoryDTO>> Get()
        {
            return await _context.GenderCategories.Select(x => mapper.Map<GenderCategoryDTO>(x)).ToListAsync();
        }
    }
}
