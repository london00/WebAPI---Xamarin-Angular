using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UdemyDotNetCoreAngular.Configuration;
using UdemyDotNetCoreAngular.DAL;
using UdemyDotNetCoreAngular.Domain.Models;
using UdemyDotNetCoreAngular.DTO;

namespace UdemyDotNetCoreAngular.Controllers
{
    public class AuthController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly IContext context;
        private readonly JWTSetting jwtOptions;

        public AuthController(IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IContext context, IOptionsSnapshot<JWTSetting> options) : base(mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.context = context;
            this.jwtOptions = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            var user = await this.userManager.FindByEmailAsync(userDTO.Email.Trim());

            if (user != null && await this.userManager.CheckPasswordAsync(user, userDTO.Password))
            {
                // TODO: Create a JWT token
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("UserId", user.Id,ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return Ok(new
                {
                    token = token,

                });
            }
            else
            {
                ModelState.AddModelError(nameof(userDTO.Password), "Username or password is incorrect.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email
            };
            var userResult = await userManager.CreateAsync(user, userDTO.Password);

            if (!userResult.Succeeded)
            {
                return BadRequest(userResult.Errors);
            }

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetUserDetails()
        {
            var userID = User.Claims.First(x => x.Type == "UserId").Value;
            var user = await this.userManager.FindByIdAsync(userID);
            return Ok(new
            {
                user.UserName,
                user.Email,
                user.PhoneNumber,
                roles = await this.userManager.GetRolesAsync(user),
                claims = await this.userManager.GetClaimsAsync(user)
            });
        }
    }
}