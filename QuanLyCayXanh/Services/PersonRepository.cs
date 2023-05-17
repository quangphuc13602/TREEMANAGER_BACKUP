using QuanLyCayXanh.Entities;
using QuanLyCayXanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly QLCayxanhContext _context;
        public PersonRepository(QLCayxanhContext context)
        {
            _context = context;
        }

        public List<NhanVienModel> GetById(string CMND)
        {
            var nhanvien = _context.NhanViens
            .Join(
                _context.ChucVus,
                nv => nv.MaChucVu,
                cvu => cvu.MaChucVu,
                (nv , cvu) => new { nhanvien = nv, chucvu = cvu}
                )
            .Select(nv => new NhanVienModel
            {
                Cmnd = nv.nhanvien.Cmnd,
                TenNhanVien = nv.nhanvien.TenNhanVien,
                DiaChi = nv.nhanvien.DiaChi,
                Email = nv.nhanvien.Email,
                Sdt = nv.nhanvien.Sdt,
                GioiTinh = nv.nhanvien.GioiTinh,
                NgaySinh = nv.nhanvien.NgaySinh,
                TenChucVu = nv.chucvu.TenChucVu,
            }).ToList().Where(nv => nv.Cmnd == CMND);
            return nhanvien.ToList();
        }

        public List<NhanVVienCongViec> GetWorkByID(string CMND)
        {
            var results = _context.NhanViens
                .Join(
                _context.CongViecs,
                nv => nv.Cmnd,
                cv => cv.NhanVien,
                (nv, cv) => new { nhanvien = nv, congviec = cv }
                )
                .Join(
                _context.CayXanhs,
                cv => cv.congviec.MaCay,
                cx => cx.MaCay,
                (cv, cx) => new { cv.congviec, cv.nhanvien, cayxanh = cx }
                )
                .Join(
                _context.ViTris,
                cxvt => cxvt.cayxanh.ViTri,
                vt => vt.MaToaDo,
                (cxvt, vt) => new { cxvt.cayxanh, cxvt.congviec, cxvt.nhanvien, vitri = vt }
                )
                .Join(
                _context.Duongs,
                cxv => cxv.vitri.MaDuong,
                d => d.MaDuong,
                (cxv, d) => new { cxv.cayxanh, cxv.vitri, cxv.congviec, cxv.nhanvien, duong = d }
                )
                .Join(
                _context.LoaiCongViecs,
                nvv => nvv.congviec.MaLoaiCv,
                lo => lo.MaLoaiCongViec,
                (nvv, lo) => new { nvv.congviec, nvv.cayxanh, nvv.duong, nvv.nhanvien, nvv.vitri, loaicongviec = lo }
                ).Where(nv => nv.nhanvien.Cmnd == CMND)
                .Select(
                n => new NhanVVienCongViec
                {
                    //maNhanVien = n.nhanvien.Cmnd
                    tenNhanVien = n.nhanvien.TenNhanVien,
                    tenCongViec = n.loaicongviec.TenCongViec,
                    mota = n.congviec.MoTa,
                    TenCay = n.cayxanh.TenCay,
                    Vitri = n.cayxanh.ViTri,
                    Duong = n.duong.TenDuong,
                    NgayBatDau = (DateTime)n.congviec.NgayBatDau,
                    NgayKetThuc = (DateTime)n.congviec.NgayKetThuc,
                    TrangThaiCV = n.congviec.TrangThai
                }
                ).ToList();
            return results.ToList();
        }
    }
}
