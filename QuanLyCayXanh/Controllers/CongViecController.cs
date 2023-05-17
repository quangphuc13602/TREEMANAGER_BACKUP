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
    public class CongViecController : ControllerBase
    {
        private readonly ICongViecRepository _congViecRepository;
        public CongViecController(ICongViecRepository congViecRepository)
        {
            _congViecRepository = congViecRepository;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                return Ok(_congViecRepository.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("status")]
        public IActionResult UpdateStatus([FromQuery] CongViecModel congViecModel)
        {
            try
            {
                if (_congViecRepository.UpdateStatus(congViecModel) == null)
                {
                    return NotFound();
                }
                else
                {
                    _congViecRepository.UpdateStatus(congViecModel);
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
