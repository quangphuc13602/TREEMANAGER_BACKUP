using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyCayXanh.Entities;
using QuanLyCayXanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiCongViecController : ControllerBase
    {
        private readonly QLCayxanhContext _context;
        public LoaiCongViecController (QLCayxanhContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetLoaiCongViec()
        {
            var loaiCV = _context.LoaiCongViecs.ToList();
            return Ok(loaiCV);
        }
        [HttpPost]
        public IActionResult AddLoaiCV(LoaiCongViecModel loaiCongViec)
        {
            var loai = _context.LoaiCongViecs.SingleOrDefault(lo => lo.MaLoaiCongViec == loaiCongViec.MaLoaiCongViec);
            if(loai != null)
            {
                return Ok(loai);
            }
            else
            {
                var loaicv = new LoaiCongViec
                {
                    MaLoaiCongViec = loaiCongViec.MaLoaiCongViec,
                    TenCongViec = loaiCongViec.TenLoaiCongVIec
                };
                _context.LoaiCongViecs.Add(loaicv);
                _context.SaveChanges();
                return Ok(loaicv);
            }
        }
    }
}
