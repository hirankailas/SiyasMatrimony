using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiyasMatrimony.API.Data;

namespace SiyasMatrimony.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMatrimonyRepository _repository;
        private readonly IMapper _mapper;

        public UserController(IMatrimonyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetUser{id}",Name ="GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repository.GetUser(id);
            var userToReturn = _mapper.Map<UserForDetailedDto>(user);
            return Ok(userToReturn);
        }

        // [HttpPost("RegisterUser")]
        // public async Task<IActionResult> RegisterUser(UserForRegisterDto userForRegisterDto)
        // {
        //     var user = await _repository.
        // }
    }
}