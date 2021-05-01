using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.IServices;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using OnlineShop.DTOModels.AuthenticationResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResult<AuthenticationResponse> Login(UserDTO input)
        {
            return _userRepository.Login(input);
        }

        public ActionResult<AuthenticationResponse> Register(UserDTO input)
        {
            return _userRepository.Register(input);
        }

        public ActionResult<UserDTO> GetById(Guid userId)
        {
            return _userRepository.GetById(userId);
        }
    }
}
