using Microsoft.AspNetCore.Mvc;
using OnlineShop.DTOModels;
using OnlineShop.DTOModels.AuthenticationResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DAL.IRepositories
{
    public interface IUserRepository
    {
        public ActionResult<AuthenticationResponse> Register(UserDTO input);
        public ActionResult<UserDTO> GetById(Guid userId);
        public ActionResult<AuthenticationResponse> Login(UserDTO input);
    }
}
