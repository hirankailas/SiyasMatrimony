using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SiyasMatrimony.API.Helper;
using SiyasMatrimony.API.Models;

namespace SiyasMatrimony.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public AuthController(IConfiguration configuration, IMapper mapper, UserManager<User> userManager,
            SignInManager<User> signInManager,RoleManager<Role> roleManager)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles="Admin")]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCreate = _mapper.Map<User>(userForRegisterDto);
            var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);
            var userToReturn = _mapper.Map<UserForDetailedDto>(userToCreate);
            var messageToUser = "Siyas Matrimony - Your Credential Information";
            if (result.Succeeded)
            {
                var userToAdd = _userManager.FindByNameAsync(userToCreate.UserName).Result;
                _userManager.AddToRoleAsync(userToAdd,"Member").Wait();
                messageToUser = string.Concat(messageToUser, $" UserName is {userForRegisterDto.UserName} and the Password is {userForRegisterDto.Password}");
                GbHelper.SendMail(userForRegisterDto.UserName, userForRegisterDto.Email, messageToUser);
                return CreatedAtRoute("GetUser", new { controller = "User", id = userToCreate.Id }, userToReturn);
            }

            
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userForLoginDto.UserName);

            var result = await _signInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

            if(result.Succeeded)
            {
                var appUser = await _userManager.Users.Include(p => p.Photos).Include(q=>q.UserRoles).FirstOrDefaultAsync(usr => 
                usr.NormalizedUserName == userForLoginDto.UserName.ToUpper());

                var userToReturn = _mapper.Map<UserForListDto>(appUser);

                return Ok(new
                {
                    token = GenerateJwtToken(appUser),
                    user = userToReturn
                });
            }

            return Unauthorized();
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName)
            };

            // var claims = new Claim[]
            // {
            //     new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            //     new Claim(ClaimTypes.Name,user.UserName)
            // };

            var roles = await _userManager.GetRolesAsync(user);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Appsettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}