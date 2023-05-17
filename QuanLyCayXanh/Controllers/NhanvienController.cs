using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyCayXanh.Models;
using QuanLyCayXanh.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanvienController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        public NhanvienController(IPersonRepository personRepository)
        {
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
    }
}
