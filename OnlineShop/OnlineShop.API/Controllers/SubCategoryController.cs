using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.IServices;
using OnlineShop.BLL.Services;
using OnlineShop.DTOModels;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            this._subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<SubCategoryDTO>> Get()
        {
            return await _subCategoryService.Get();
        }

        [HttpGet]
        [Route("/api/Subcategory/{id}/Category")]
        public async Task<IEnumerable<SubCategoryDTO>> Get(int id)
        {
            return await _subCategoryService.GetByCategory(id);
        }
    }
}
