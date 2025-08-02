using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        // private readonly UserManager<User> _userManager;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            // _userManager = userManager;
        }

        [HttpGet("testing")]
        public IActionResult Index()
        {
            return StatusCode(502, "Test Complete");
        }
        
    }
}