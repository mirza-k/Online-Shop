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
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper mapper;

        public SubCategoryRepository(OnlineShopContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<SubCategoryDTO>> Get()
        {
            return await _context.SubCategories.Select(x => mapper.Map<SubCategoryDTO>(x)).ToListAsync();
        }
        public async Task<IEnumerable<SubCategoryDTO>> GetByCategory(int id)
        {
            return await _context.SubCategories.Where(x => x.CategoryId == id).Select(x => mapper.Map<SubCategoryDTO>(x)).ToListAsync();
        }
    }
}
