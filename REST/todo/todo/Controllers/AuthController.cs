using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using todo.Dtos;
using todo.Helpers;
using todo.Models;
using todo.Services.Repository;

namespace todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        ITodoRepository _reppo;
        IConfiguration _config;

        public AuthController(ITodoRepository reppo,IConfiguration config)
        {
            _reppo = reppo;
            _config = config;
        }

        [HttpPost]
        [Route("Register")]
         public IActionResult  Register(RegisterDto userDatils)
        {

            var user =  _reppo.GetOneUser(userDatils.Email);
            if(user is null)
            {
                TodoUser NewUser = new()
                {
                    Email = userDatils.Email,
                    FullName = userDatils.FullName,
                    Password = BCrypt.Net.BCrypt.HashPassword(userDatils.Password),
                };
                _reppo.RegisterUser(NewUser);

                return Ok("Registration sucessfull");
            }
            return Unauthorized("User already exists");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult login(LoginDto loginCredintals)
        {
            var CurrentUser = _reppo.GetOneUser(loginCredintals.Email);

            if (CurrentUser != null)
            {
                bool IsPassMatch = BCrypt.Net.BCrypt.Verify(loginCredintals.Password, CurrentUser.Password);
                if(IsPassMatch)
                {
                    return Ok(Helper.Responce(false, "Login Successfull", new
                    {
                        token = GenerateToken(CurrentUser),
                        fullName=CurrentUser.FullName,
                        email=CurrentUser.Email
                    }));
                }
                else
                {
                    return Unauthorized(Helper.Responce(true, "Invalid Password", null));
                }

            }
            else
            {
                return Unauthorized(Helper.Responce(true, "Invalid Email Address", null));
            }

        }

        [Authorize]
        [HttpGet]
        [Route("/check")]
        public IActionResult CheckJwt()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                var email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email).Value;

            return Ok(new {message= $"Everything is working fine {email} " });
            }
            return Ok("okay but failed00");
        }



        //private methods
        private string GetCurrentUserEmail()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                var email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email).Value;
                return email;
            }
            return string.Empty;
        }
       

        private string GenerateToken(TodoUser todouser)
        {
          
            var securityKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {

                new Claim(ClaimTypes.NameIdentifier, todouser.FullName),
                new Claim(ClaimTypes.Email, todouser.Email),   
            };

           

            var token = new JwtSecurityToken(
               
               claims: claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials: credintials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
