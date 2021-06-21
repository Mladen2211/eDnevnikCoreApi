using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using eDnevnikApi.Models;
using eDnevnikApi.Database;
using eDnevnik.Interface;
using AutoMapper;

namespace eDnevnikApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly eDnevnikContext _context;
        private readonly IUser _service;
        private readonly IMapper _mapper;

        public AuthController(eDnevnikContext context, IUser service, IMapper mapper)
        {
            _context = context;
            _service = service;
            _mapper = mapper;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] AuthenticateRequest user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var password = Helpers.PasswordGenerator.GenerateHash(user.Password);
            var emp = _context.Users.FirstOrDefault(e => e.EMail == user.EMail);
            var chech = _context.Users.FirstOrDefault(e => e.EMail == user.EMail && e.Password == password);
            if (chech != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eDnevnikSecretKey@2021"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://10.15.1.9:8080",
                    audience: "http://10.15.1.9:8080",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString, user = _service.GetById(chech.Id).Result });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}