using Microsoft.AspNetCore.Mvc;
using OnlineShop.DTOModels;
using OnlineShop.DTOModels.AuthenticationResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BLL.IServices
{
    public interface IUserService
    {
        public ActionResult<AuthenticationResponse> Register(UserDTO input);
        public ActionResult<AuthenticationResponse> Login(UserDTO input);
        public ActionResult<UserDTO> GetById(Guid userId);

    }
}
