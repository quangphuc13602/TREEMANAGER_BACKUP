using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyCayXanh.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CayxanhController : ControllerBase
    {
        private readonly ICayxanhRepository _cayxanhRepository;
        public CayxanhController(ICayxanhRepository cayxanhRepository)
        {
            _cayxanhRepository = cayxanhRepository;
        }

        [HttpGet("old")]
        public IActionResult GetAllTrees([FromQuery] int old)
        {
            try
            {
                return Ok(_cayxanhRepository.GetByOld(old));
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("street")]
        public IActionResult GetTreeByStreet( [FromQuery] string street)
        {
            try
            {
                return Ok(_cayxanhRepository.GetbyStreet(street));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("id")]
        public IActionResult GetById([FromQuery] string id)
        {
            try
            {
                return Ok(_cayxanhRepository.Getbyid(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("commune")]
        public IActionResult GetBycommune([FromQuery] string commune)
        {
            try
            {
                return Ok(_cayxanhRepository.GetbyCommune(commune));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
