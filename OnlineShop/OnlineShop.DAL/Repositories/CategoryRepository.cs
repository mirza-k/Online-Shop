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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper mapper;
        private readonly OnlineShopContext _context;

        public CategoryRepository(IMapper mapper, OnlineShopContext context)
        {
            this.mapper = mapper;
            this._context = context;
        }
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            return await _context.Categories.Select(x => mapper.Map<CategoryDTO>(x)).ToListAsync();
        }
    }
}
