using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using SiyasMatrimony.API.Models;
using Microsoft.EntityFrameworkCore;
using SiyasMatrimony.API.Data;
using System.Linq;
using SiyasMatrimony.API.DTOS;

namespace SiyasMatrimony.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController:ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;

        public AdminController(DataContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }    

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("GetUsersWithRoles")]
        public async Task<IActionResult> GetUsersWithRoles()
        {
            var userList = await (from user in _context.Users orderby user.UserName
                            select new 
                            {
                                Id = user.Id,
                                UserName = user.UserName,
                                Roles = (from userrole in user.UserRoles
                                join role in _context.Roles
                                on userrole.RoleId equals role.Id
                                select role.Name).ToList()
                            }).ToListAsync();

                            return Ok(userList);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("EditRoles/{userName}")]
        public async Task<IActionResult> EditRoles(string userName, RoleEditDto roleEditDto)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var userRoles = await _userManager.GetRolesAsync(user);
            var selectedRoles = roleEditDto.RoleNames;
            selectedRoles = selectedRoles ?? new string[] {};

            var result = await _userManager.AddToRolesAsync(user,selectedRoles.Except(userRoles));

            if(!result.Succeeded)
            {
                return BadRequest("Failed to add the roles");
            }

            result = await _userManager.RemoveFromRolesAsync(user,userRoles.Except(selectedRoles));

            if(!result.Succeeded)
            {
                return BadRequest("Failed to remove the roles");
            }

            return Ok(await _userManager.GetRolesAsync(user));
        }
       
        //=> Ok("Only Admins can see this");

        [Authorize(Policy = "RequireMemberRole")]
        [HttpGet("GetMemberWithRoles")]
        public IActionResult GetMemberWithRoles() => Ok("Only Member can see this");
    }
}