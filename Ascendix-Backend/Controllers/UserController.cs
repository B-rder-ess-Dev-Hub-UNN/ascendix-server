using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Ascendix_Backend.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("testing")]
        public IActionResult Index()
        {
            return StatusCode(502, "Test Complete");
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] RegisterUser register)
        {
            var user = await _userRepo.createUser(register.email, register.password);
            if (user.User == null) return StatusCode(502, $"{user.ErrorMessage}");
            var token = await _userRepo.token(user.User.Id);
            return Ok(new
            {
                Email = register.email,
                token = token,
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginUser login)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var user = await _userRepo.loginUser(login.email, login.password);
#pragma warning restore CS8604 // Possible null reference argument.
            if (user.User == null) return BadRequest(user.ErrorMessage);
            var token = await _userRepo.token(user.User.Id);
            return Ok(new
            {
                Email = login.email,
                token = token,
            });
        }

        [HttpPost("add-wallet-address")]
        public async Task<IActionResult> addWalletAddress([FromBody] string address)
        {
            return StatusCode(404, "");
        }
        
    }
}