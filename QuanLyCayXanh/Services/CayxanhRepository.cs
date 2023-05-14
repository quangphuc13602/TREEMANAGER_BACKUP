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
        public void Add(CayxanhModel cayxanhModel)
        {
            throw new NotImplementedException();
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
                   TrangThai = c.cayxanh.TrangThai
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


    }
}
