using Microsoft.AspNetCore.Mvc;
using OnlineShop.DTOModels;
using OnlineShop.DAL.IRepositories;
using OnlineShop.Models;
using System;
using OnlineShop.DTOModels.AuthenticationResponse;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using OnlineShop.DAL.JWT;
using Microsoft.Extensions.Options;
using AutoMapper;
//using Microsoft.Extensions.Options;

namespace OnlineShop.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper mapper;
        private readonly JwtConfig _jwtConfig;

        public UserRepository(OnlineShopContext context, IOptionsMonitor<JwtConfig> optionsMonitor,IMapper mapper)
        {
            _jwtConfig = optionsMonitor.CurrentValue;
            _context = context;
            this.mapper = mapper;
        }

        public ActionResult<AuthenticationResponse> Login(UserDTO input)
        {
            UserAccount userAccount = _context.UserAccounts.FirstOrDefault(x => x.Username == input.Username && x.PasswordHash == input.Password);
            if (userAccount != null)
            {
                User user = _context.Users.Include(x => x.UserAccount).Include(x=>x.Role).FirstOrDefault(x => x.UserAccountId == userAccount.UserAccountId);

                var jwtToken = GenerateJwtToken(user);
                return new AuthenticationResponse()
                {
                    Token = jwtToken,
                    Success = true,
                    Errors = null
                };
            }

            return new AuthenticationResponse()
            {
                Token = null,
                Success = false,
                Errors = new List<string>() { "Invalid username or password." }
            };
        }

        public ActionResult<AuthenticationResponse> Register(UserDTO input)
        {
            UserAccount sameUsername = _context.UserAccounts.FirstOrDefault(x => x.Username == input.Username);
            if (sameUsername != null)
            {
                return new AuthenticationResponse()
                {
                    Token = null,
                    Errors = new List<string>() { "User with same username already exists." },
                    Success = false
                };
            }

            UserAccount userAccount = _context.UserAccounts.Add(new UserAccount
            {
                UserAccountId = Guid.NewGuid(),
                Email = input.Email,
                PasswordHash = input.Password,
                PhoneNumber = "062-321-123",
                Username = input.Username
            }).Entity;
            _context.SaveChanges();

            if (userAccount != null)
            {
                User model = _context.Users.Add(new User
                {
                    UserId = Guid.NewGuid(),
                    Address = "Elm Street",
                    DateBirth = DateTime.Now,
                    CityId = 11,
                    FirstName = "Test",
                    LastName = "Test",
                    GenderId = 1,
                    UserAccountId = userAccount.UserAccountId,
                    RoleId = 1
                }).Entity;
                _context.SaveChanges();

                var user = _context.Users.Include(x => x.UserAccount).Include(x => x.Role).FirstOrDefault(x => x.UserId == model.UserId);

                var token = GenerateJwtToken(user);
                return new AuthenticationResponse()
                {
                    Token = token,
                    Errors = null,
                    Success = true
                };
            }
            else
            {
                return new AuthenticationResponse()
                {
                    Token = null,
                    Errors = null,
                    Success = false
                };
            }
        }

        public ActionResult<UserDTO> GetById(Guid userId)
        {
            var user = _context.Users.Include(x=>x.UserAccount).FirstOrDefault(x=>x.UserId == userId);
            return mapper.Map<UserDTO>(user);
        }

        private string GenerateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("Username", user.UserAccount.Username),
                    new Claim("Email", user.UserAccount.Email),
                    new Claim("Role", user.Role.Name),
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1000),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
