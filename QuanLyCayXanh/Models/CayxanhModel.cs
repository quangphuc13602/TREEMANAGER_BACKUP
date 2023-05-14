using QuanLyCayXanh.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Models
{
    public class CayxanhModel
    {
        public string hinhAnh { get; set; }
        public string TenCay { get; set; }
        public int? Tuoi { get; set; }
        public string MoTaCay { get; set; }
        public string ViTri { get; set; }
        public string LoaiCay { get; set; }
        public string TrangThai { get; set; }
    }
    public class CayxanhVM : CayxanhModel
    {
        public string MaCay { get; set; }
    }
    public class CayxanhDuong
    {
        public string MaCay { get; set; }
        public string hinhAnh { get; set; }
        public string TenCay { get; set; }
        public string vitri { get; set; }
        public string duong { get; set; }
        public string TrangThai { get; set; }

    }
    public class CayxanhDuongPhuongQuan
    {
        public string MaCay { get; set; }
        public string hinhAnh { get; set; }

        public string TenCay { get; set; }
        public string vitri { get; set; }
        public string duong { get; set; }
        public string phuong { get; set; }
        public string quan { get; set; }
        public string TrangThai { get; set; }

    }
    public class CayxanhDuongPhuong
    {
        public string MaCay { get; set; }
        public string hinhAnh { get; set; }
        public string TenCay { get; set; }
        public string vitri { get; set; }
        public string duong { get; set; }
        public string phuong { get; set; }
        public string TrangThai { get; set; }
    }
    public class CayXanhDetail
    {
        public string Macay { get; set; }
        public string hinhAnh { get; set; }
        public string TenCay { get; set; }
        public int? Tuoi { get; set; }
        public string MoTaCay { get; set; }
        public string ViTri { get; set; }
        public string duong { get; set; }
        public string phuong { get; set; }
        public string Quan { get; set; }
        public string TrangThai { get; set; }
    }
    public class CayXanhNguoi : CayxanhVM
    {
        public string MaNV { get; set; }
        public string NguoiChamSoc { get; set; }
    }
}
