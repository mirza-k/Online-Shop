using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.IServices;
using OnlineShop.DTOModels;
using OnlineShop.DTOModels.AuthenticationResponse;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public ActionResult<AuthenticationResponse> Register([FromBody] UserDTO input)
        {
            return _userService.Register(input);
        }

        [HttpPost("login")]
        public ActionResult<AuthenticationResponse> Login([FromBody] UserDTO input)
        {
            return _userService.Login(input);
        }

        [HttpGet("{userId}")]
        public ActionResult<UserDTO> GetById(Guid userId)
        {
            //napravit automapper
            return _userService.GetById(userId);
        }
    }
}
