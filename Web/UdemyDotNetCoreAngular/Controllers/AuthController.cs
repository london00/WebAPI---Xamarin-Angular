using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UdemyDotNetCoreAngular.DAL;
using UdemyDotNetCoreAngular.Domain;
using UdemyDotNetCoreAngular.Domain.Models;
using UdemyDotNetCoreAngular.DTO;

namespace UdemyDotNetCoreAngular.Controllers
{
    public class AuthController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IContext context;

        public AuthController(IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IContext context) : base(mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> LogIn()
        {
            
            return Ok();
        }
    }
}