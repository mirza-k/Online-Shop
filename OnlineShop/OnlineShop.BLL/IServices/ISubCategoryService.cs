using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.IServices
{
   public interface ISubCategoryService
    {
        public Task<IEnumerable<SubCategoryDTO>> Get();
        public Task<IEnumerable<SubCategoryDTO>> GetByCategory(int id);

    }
}
