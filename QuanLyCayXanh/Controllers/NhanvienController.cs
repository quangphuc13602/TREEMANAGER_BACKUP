using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuanLyCayXanh.Entities;
using QuanLyCayXanh.Models;
using QuanLyCayXanh.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanvienController : ControllerBase
    {

        private readonly QLCayxanhContext _context;
        private readonly IPersonRepository _personRepository;

        public NhanvienController(QLCayxanhContext context, IPersonRepository personRepository)
        {
            _context = context;
            _personRepository = personRepository;
        }

        [HttpGet("id")]
        public IActionResult GetById([FromQuery]string id)
        {
            try
            {
                return Ok(_personRepository.GetById(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("WorkByID")]
        public IActionResult GetWorkById([FromQuery] string id)
        {
            try
            {
                return Ok(_personRepository.GetWorkByID(id));
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserModel loginDto)
        {
            try
            {
                var user = await _context.NhanViens.FirstOrDefaultAsync(u => u.Email == loginDto.gmail & u.Password == loginDto.password);
                if (user == null)
                {
                    return Unauthorized();
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("SecretKey");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
            new Claim(ClaimTypes.Email, user.Email.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(tokenString);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
