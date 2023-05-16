using Microsoft.EntityFrameworkCore;
using QuanLyCayXanh.Entities;
using QuanLyCayXanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Services
{
    public class CayxanhRepository : ICayxanhRepository
    {
        private readonly QLCayxanhContext _context;
        public CayxanhRepository(QLCayxanhContext context)
        {
            _context = context;
        }
        public void Add(CayxanhVM cayxanhVM)
        {
            var _cayxanh = new CayXanh
            {
                MaCay = cayxanhVM.MaCay,
                TenCay = cayxanhVM.TenCay,
                Tuoi = cayxanhVM.Tuoi,
                MoTaCay = cayxanhVM.MoTaCay,
                ViTri = cayxanhVM.ViTri,
                LoaiCay = cayxanhVM.LoaiCay,
                TrangThai = cayxanhVM.TrangThai
            };
            _context.CayXanhs.Add(_cayxanh);
            _context.SaveChanges();
        }

        public List<CayXanhDetail> GetByOld(int old)
        {
            var cayxanh = _context.CayXanhs
            .Join(
            _context.AnhCays,
            cx => cx.MaCay,
            ac => ac.MaCay,
            (cx, ac) => new {cayxanh = cx, anhcay = ac}
            )
            .Join(
            _context.ViTris,
            cxvt => cxvt.cayxanh.ViTri,
            vt => vt.MaToaDo,
            (cxvt, vt) => new { cxvt.cayxanh, cxvt.anhcay , vitri = vt }
            )
            .Join(
            _context.Duongs,
            cxv => cxv.vitri.MaDuong,
            d => d.MaDuong,
            (cxv, d) => new { cxv.cayxanh, cxv.vitri, cxv.anhcay , duong = d }
            )
            .Join(
             _context.Phuongs,
             vtd => vtd.duong.MaPhuong,
             p => p.MaPhuong,
             (vtd, p) => new { vtd.cayxanh, vtd.vitri, vtd.duong, vtd.anhcay , phuong = p }
             ).Select(c => new CayXanhDetail
             {
                 Macay = c.cayxanh.MaCay,
                 hinhAnh = c.anhcay.HinhAnh,
                 TenCay = c.cayxanh.TenCay,
                 Tuoi = c.cayxanh.Tuoi,
                 MoTaCay = c.cayxanh.MoTaCay,
                 ViTri = c.cayxanh.ViTri,
                 duong = c.duong.TenDuong,
                 phuong = c.phuong.TenPhuong,
                 TrangThai = c.cayxanh.TrangThai
             })
            .Where(cx => cx.Tuoi == old); //them dia chi
            return cayxanh.ToList();
        }

        public List<CayxanhDuongPhuong> GetbyCommune(string commune)
        {
            var cayxanh = _context.CayXanhs
                        .Join(
            _context.AnhCays,
            cx => cx.MaCay,
            ac => ac.MaCay,
            (cx, ac) => new { cayxanh = cx, anhcay = ac }
            )
            .Join(
            _context.ViTris,
            cxvt => cxvt.cayxanh.ViTri,
            vt => vt.MaToaDo,
            (cxvt, vt) => new { cxvt.cayxanh, cxvt.anhcay, vitri = vt }
            )
            .Join(
            _context.Duongs,
            cxv => cxv.vitri.MaDuong,
            d => d.MaDuong,
            (cxv, d) => new { cxv.cayxanh, cxv.vitri, cxv.anhcay, duong = d }
            )
            .Join(
             _context.Phuongs,
             vtd => vtd.duong.MaPhuong,
             p => p.MaPhuong,
             (vtd, p) => new { vtd.cayxanh, vtd.vitri, vtd.duong, vtd.anhcay, phuong = p }
             ).Select(c => new CayxanhDuongPhuong
             {
                 MaCay = c.cayxanh.MaCay,
                 hinhAnh = c.anhcay.HinhAnh,
                 TenCay = c.cayxanh.TenCay,
                 vitri  = c.cayxanh.ViTri,
                 duong = c.duong.TenDuong,
                 phuong = c.phuong.TenPhuong,
                TrangThai = c.cayxanh.TrangThai
             }).ToList()
             .Where(cxp => cxp.phuong == commune);
            return cayxanh.ToList();
        }

        public List<CayXanhDetail> Getbyid(string id)
        {
            var cayxanh = _context.CayXanhs
            .Join(
            _context.AnhCays,
            cx => cx.MaCay,
            ac => ac.MaCay,
            (cx, ac) => new { cayxanh = cx, anhcay = ac }
            )
            .Join(
            _context.ViTris,
            cxvt => cxvt.cayxanh.ViTri,
            vt => vt.MaToaDo,
            (cxvt, vt) => new { cxvt.cayxanh, cxvt.anhcay, vitri = vt }
            )
            .Join(
            _context.Duongs,
            cxv => cxv.vitri.MaDuong,
            d => d.MaDuong,
            (cxv, d) => new { cxv.cayxanh, cxv.vitri, cxv.anhcay, duong = d }
            )
            .Join(
             _context.Phuongs,
             vtd => vtd.duong.MaPhuong,
             p => p.MaPhuong,
             (vtd, p) => new { vtd.cayxanh, vtd.vitri, vtd.duong, vtd.anhcay, phuong = p }
             )
             .Join(
              _context.Quans,
              vtp => vtp.phuong.MaQuan,
              q =>   q.MaQuan,
              (vtp, q) => new { vtp.cayxanh, vtp.vitri, vtp.duong, vtp.phuong, vtp.anhcay, quan = q }
              )
             //.Join(
             //   _context.CongViecs,
             //   cxcv => cxcv.cayxanh.MaCay,
             //   cv => cv.MaCay,
             //   (cxcv, cv) => new { cxcv.cayxanh, cxcv.anhcay, cxcv.vitri, cxcv.duong, cxcv.phuong, cxcv.quan, congviec = cv}
             //   )
             //.Join(
             //   _context.NhanViens,
             //   cxcv => cxcv.congviec.NhanVien,
             //   nv => nv.Cmnd,
             //   (cxcv , nv) => new { cxcv.cayxanh, cxcv.anhcay, cxcv.vitri, cxcv.duong, cxcv.phuong, cxcv.quan, cxcv.congviec, nhanvien = nv}
             //   )
              .Select(c => new CayXanhDetail
               {
                   Macay = c.cayxanh.MaCay,
                   hinhAnh = c.anhcay.HinhAnh,
                   TenCay = c.cayxanh.TenCay,
                   Tuoi = c.cayxanh.Tuoi,
                   ViTri = c.cayxanh.ViTri,
                   duong = c.duong.TenDuong,
                   phuong = c.phuong.TenPhuong,
                   Quan = c.quan.TenQuan,
                   MoTaCay = c.cayxanh.MoTaCay,
                   TrangThai = c.cayxanh.TrangThai,
               }).ToList().Where(cxi => cxi.Macay == id);
            return cayxanh.ToList();
        }

        public List<CayxanhDuong> GetbyStreet(string street)
        {
            var cayxanhs = _context.CayXanhs
                 .Join(
            _context.AnhCays,
            cx => cx.MaCay,
            ac => ac.MaCay,
            (cx, ac) => new { cayxanh = cx, anhcay = ac }
            )
            .Join(
            _context.ViTris,
            cxvt => cxvt.cayxanh.ViTri,
            vt => vt.MaToaDo,
            (cxvt, vt) => new { cxvt.cayxanh, cxvt.anhcay, vitri = vt }
            )
            .Join(
            _context.Duongs,
            cxv => cxv.vitri.MaDuong,
            d => d.MaDuong,
            (cxv, d) => new { cxv.cayxanh, cxv.vitri, cxv.anhcay, duong = d }
            )
                .Select(c => new CayxanhDuong
                {
                    MaCay = c.cayxanh.MaCay,
                    hinhAnh = c.anhcay.HinhAnh,
                    TenCay = c.cayxanh.TenCay,
                    vitri = c.cayxanh.ViTri,
                    duong = c.duong.TenDuong,
                    TrangThai = c.cayxanh.TrangThai
                }).ToList().Where(cxd => cxd.duong == street);
            return cayxanhs.ToList();
        }

        public List<CayxanhVM> GetByStatus(string status)
        {
            var cayxanh = _context.CayXanhs
               .Join(
                _context.AnhCays,
                c => c.MaCay,
                ac => ac.MaCay,
                (c, ac) => new { cayxanh = c, anhcay = ac }
                )
               .Select(cx =>
                new CayxanhVM
                {
                    MaCay = cx.cayxanh.MaCay,
                    hinhAnh = cx.anhcay.HinhAnh,
                    TenCay = cx.cayxanh.TenCay,
                    TrangThai = cx.cayxanh.TrangThai,
                }
                ).ToList().Where(cx => cx.TrangThai == status);
            return cayxanh.ToList();
        }

        public List<CayxanhLoai> GetByLoai(string tenloai, string loaire, string loaithan, string loaila)
        {
            var cayxanh = _context.CayXanhs
                .Join(
                _context.LoaiCays,
                cx => cx.LoaiCay,
                l => l.MaLoaiCay,
                (cx, l) => new { cayxanh = cx, loai = l }
                ).Select(
                c => new CayxanhLoai
                {
                    TenLoaiCay = c.loai.TenLoaiCay,
                    LoaiLa = c.loai.LoaiLa,
                    LoaiRe = c.loai.LoaiRe,
                    LoaiThan = c.loai.LoaiThan,
                    MaCay = c.cayxanh.MaCay,
                    TenCay = c.cayxanh.TenCay
                }).ToList()
                .Where(lo => lo.TenLoaiCay == tenloai)
                .Where(lo => lo.LoaiRe == loaire)
                .Where(lo => lo.LoaiThan == loaithan)
                .Where(lo => lo.LoaiLa == loaila);
            return cayxanh.ToList();
        }

        public bool Remove(string macay)
        {
            var anhcay = _context.AnhCays.SingleOrDefault(ac => ac.MaCay == macay);
            var cayxanh = _context.CayXanhs.SingleOrDefault(cx => cx.MaCay == macay);
            if (cayxanh != null && anhcay != null)
            {
                _context.Remove(anhcay);
                _context.Remove(cayxanh);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<CayXanhNguoi> GetByPersonWork(string id)
        {
            var checkid = _context.CongViecs.SingleOrDefault(cx => cx.MaCay == id);
            if (checkid != null)
            {
                var cayxanh = _context.CayXanhs
                .Join(
                   _context.CongViecs,
                   cx => cx.MaCay,
                   cv => cv.MaCay,
                   (cx, cv) => new { cayxanh = cx, congviec = cv }
                   )
                .Join(
                   _context.NhanViens,
                   cxcv => cxcv.congviec.NhanVien,
                   nv => nv.Cmnd,
                   (cxcv, nv) => new { cxcv.cayxanh, cxcv.congviec, nhanvien = nv }
                   )
                   .Select(cx => new CayXanhNguoi
                   {
                       MaCay = cx.cayxanh.MaCay,
                       TenCay = cx.cayxanh.TenCay,
                       ViTri = cx.cayxanh.ViTri,
                       NguoiChamSoc = cx.nhanvien.TenNhanVien,
                       congviec = cx.congviec.MoTa
                   }).ToList().Where(cx => cx.MaCay == id);
                return cayxanh.ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
