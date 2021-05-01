using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.IServices;
using OnlineShop.DTOModels;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesSizeController : ControllerBase
    {
        private readonly IClothesSizeService _clothesSizeService;

        public ClothesSizeController(IClothesSizeService clothesSizeService)
        {
            this._clothesSizeService = clothesSizeService;
        }

        [HttpGet]
        public async Task<IEnumerable<ClothesSizeDTO>> Get()
        {
            return await _clothesSizeService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ClothesSizeDTO> GetById(int id)
        {
            return await _clothesSizeService.GetById(id);
        }
    }
}
