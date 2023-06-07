//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using QuanLyCayXanh.Entities;
//using QuanLyCayXanh.Models;
//using QuanLyCayXanh.Services;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        private readonly AppSettings _appSettings;

        public NhanvienController(QLCayxanhContext context, IPersonRepository personRepository, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _context = context;
            _personRepository = personRepository;
            _appSettings = optionsMonitor.CurrentValue;
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

        [HttpPost("Login")]
        public IActionResult Validate(UserModel userModel)
        {
            var user = _context.NhanViens.SingleOrDefault(u => u.Email == userModel.Email & u.Password == userModel.Password);

            if(user == null)
            {
                return Ok(new ApiResponse {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }
            //cấp token

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = GenerateToken(user)
            }) ;
        }
        private string GenerateToken(NhanVien nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.Secretkey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, nguoiDung.TenNhanVien),
                    new Claim("UserName", nguoiDung.Email),
                    new Claim("Id", nguoiDung.Cmnd.ToString()),

                    //roles

                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1), //thoi gian het han
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}
