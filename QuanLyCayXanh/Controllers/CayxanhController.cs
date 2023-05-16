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
        [HttpGet("status")]
        public IActionResult GetByStatus([FromQuery] string status)
        {
            try
            {
                return Ok(_cayxanhRepository.GetByStatus(status));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Type")]
        public IActionResult GetByLoai([FromQuery] string tenloai, string loaire, string loaithan, string loaila)
        {
            try
            {
                //List<CayxanhLoai> results = _cayxanhRepository.GetByLoai(tenloai, loaire, loaithan, loaila);
                //if (results == null)
                //{
                //    return NotFound();
                //}
                return Ok(_cayxanhRepository.GetByLoai(tenloai, loaire, loaithan, loaila));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("CayXanh")]
        public IActionResult CreateTree(CayxanhVM cayxanhVM)
        {
            try{
                _cayxanhRepository.Add(cayxanhVM);
                return Ok(cayxanhVM);
            }
            catch{
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Remove([FromQuery] string id)
        {
            try
            {
                var rel = _cayxanhRepository.Remove(id);
                if (rel)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("idpersonwork")]
        public IActionResult GetByPersonWork([FromQuery] string id)
        {
            try
            {
                var result = _cayxanhRepository.GetByPersonWork(id);
                if(result != null)
                {
                    return Ok(_cayxanhRepository.GetByPersonWork(id));

                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
