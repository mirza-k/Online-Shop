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
    public class GenderCategoryController : ControllerBase
    {
        private readonly IGenderCategoryService _genderCategoryService;

        public GenderCategoryController(IGenderCategoryService genderCategoryService)
        {
            this._genderCategoryService = genderCategoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<GenderCategoryDTO>> Get()
        {
            return await _genderCategoryService.Get();
        }
    }
}
