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
    public class ShoeSizeController : ControllerBase
    {
        private readonly IShoeSizeService _shoeSizeService;

        public ShoeSizeController(IShoeSizeService shoeSizeService)
        {
            this._shoeSizeService = shoeSizeService;
        }

        [HttpGet]
        public IEnumerable<ShoeSizesDto> Get()
        {
            return _shoeSizeService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ShoeSizesDto> GetById(int id)
        {
            return await _shoeSizeService.GetById(id);
        }
    }
}
