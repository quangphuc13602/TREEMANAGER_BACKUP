using QuanLyCayXanh.Entities;
using QuanLyCayXanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Services
{
    public class CongViecRepository : ICongViecRepository
    {
        private readonly QLCayxanhContext _context;
        public CongViecRepository(QLCayxanhContext context)
        {
            _context = context;
        }

        public List<CongViecModel> GetAll()
        {
            var congviecs = _context.CongViecs
                .Join(
                _context.LoaiCongViecs,
                cv => cv.MaLoaiCv,
                lo => lo.MaLoaiCongViec,
                (cv, lo)=> new {congviec = cv, loaicv = lo}
                )
                .Select(c => new CongViecModel {
                MaCongViec = c.congviec.MaCongViec,
                MaLoaiCv = c.loaicv.TenCongViec,
                MoTa = c.congviec.MoTa,
                MaCay = c.congviec.MaCay,
                NgayBatDau = c.congviec.NgayBatDau,
                NgayKetThuc = c.congviec.NgayKetThuc,
                NhanVien = c.congviec.NhanVien,
                TrangThai = c.congviec.TrangThai
                }).ToList();
            return congviecs.ToList();
        }

        public CongViecModel UpdateStatus(CongViecModel congViecModel)
        {
            var congviec = _context.CongViecs.SingleOrDefault(cv => cv.MaCongViec == congViecModel.MaCongViec);
            //var nhanvien = _context.CongViecs.SingleOrDefault(cv => cv.NhanVien == congViecModel.NhanVien);
            //var cayxanh = _context.CongViecs.SingleOrDefault(cv => cv.MaCay == congViecModel.MaCay);
            if (congviec.MaCongViec == congViecModel.MaCongViec & congviec.NhanVien == congViecModel.NhanVien & congviec.MaCay == congViecModel.MaCay)
            {
                congviec.TrangThai = congViecModel.TrangThai;
                _context.SaveChanges();
                return new CongViecModel
                {
                    MaCongViec = congviec.MaCongViec,
                    MoTa = congviec.MoTa,
                    MaCay = congviec.MaCay,
                    NhanVien = congviec.NhanVien,
                    NgayBatDau = congviec.NgayBatDau,
                    NgayKetThuc = congviec.NgayKetThuc,
                    TrangThai = congviec.TrangThai
                };
            }
            else
            {
                return null;
            }
        }
        
    }
}
